using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum SpeedsPlayer { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fasters = 4 };
public enum Gamemodes { Cube = 0, Ship = 1, Ball = 2, UFO = 3, Wave = 4 };
public class Movement : MonoBehaviour
{
    public SpeedsPlayer CurrentSpeeds;
    public Gamemodes CurrentGamemode;

    float[] SpeedValues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f };

    [System.NonSerialized]  public int[] screenHeightValues = { 11, 10, 8, 10, 10 };
    [System.NonSerialized] public float yLastPortal = -2.3f;

    public float GroundCheckRadius;
    public LayerMask GroundMask;
    public Transform Sprite;

    private float currentAngle = 0f;
    private float targetAngle = 0f;
    private float rotationSpeed = 360f;

    public float jumpForce = 50f;

    public Sprite CubeSprite;
    public Sprite ShipSprite;
    public Sprite BallSprite;
    public Sprite UFOSprite;
    public Sprite WaveSprite;

    Rigidbody2D rb;

    public int Gravity = 1;
    public bool clickProcessed = false;

    void Start()
    {
        //считывание состояния объекта
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * SpeedValues[(int)CurrentSpeeds] * Time.deltaTime;
        Invoke(CurrentGamemode.ToString(), 0);
    }

    public bool OnGrounded()
    {
        return Physics2D.OverlapBox(transform.position + Vector3.down * Gravity * 0.5f, Vector2.right * 1.1f + Vector2.up * GroundCheckRadius, 0, GroundMask);
    }

    bool TouchingWall()
    {
        return Physics2D.OverlapBox((Vector2)transform.position + (Vector2.right * 0.55f), Vector2.up * 0.8f + (Vector2.right * GroundCheckRadius), 0, GroundMask);
    }

    void Cube()
    {
        Generic.createGamemode(rb, this, true, 19.5269f, 9.057f, true, false, 409.1f);
        Sprite.GetComponent<SpriteRenderer>().sprite = CubeSprite;
    }

    void Ball()
    {
        Generic.createGamemode(rb, this, true, 0, 6.2f, false, true);
        Sprite.GetComponent<SpriteRenderer>().sprite = BallSprite;
    }
    void UFO()
    {
        Generic.createGamemode(rb, this, false, 10.841f, 4.1483f, false, false, 0, 10.841f);
        Sprite.GetComponent<SpriteRenderer>().sprite = UFOSprite;
    }

    void Wave()
    {
        float moveDirection = Input.GetMouseButton(0) ? 1 : -1;

        targetAngle = moveDirection > 0 ? 45f : -45f;

        currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

        if (moveDirection == 0)
        {
            currentAngle = 0;
        }

        transform.rotation = Quaternion.Euler(0, 0, currentAngle);

        rb.velocity = new Vector2(0, SpeedValues[(int)CurrentSpeeds] * moveDirection * Gravity);

        Sprite.GetComponent<SpriteRenderer>().sprite = WaveSprite;
    }

    void Ship()
    {
        rb.gravityScale = 2.93f * (Input.GetMouseButton(0) ? -1 : 1) * Gravity;
        Generic.LimitYVelocity(9.95f, rb);
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 2);
        Sprite.GetComponent<SpriteRenderer>().sprite = ShipSprite;
    }

    public void ChangeThoughPortal(Gamemodes Gamemode, SpeedsPlayer Speed, int gravity, int State, float yPortal)
    {
        switch (State)
        {
            case 0:
                CurrentSpeeds = Speed;
                break;
            case 1:
                yLastPortal = yPortal;
                CurrentGamemode = Gamemode;
                break;
            case 2:
                Gravity = gravity;
                rb.gravityScale = Mathf.Abs(rb.gravityScale) * (int)gravity;

                // Отражение спрайта по горизонтали
                Vector3 currentScale = Sprite.GetComponent<SpriteRenderer>().transform.localScale;
                currentScale.y *= -1; // Изменяем знак масштаба по оси Y
                Sprite.GetComponent<SpriteRenderer>().transform.localScale = currentScale; // Применяем измененный масштаб

                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PortalScripts portal = collision.gameObject.GetComponent<PortalScripts>();
        if (portal)
        {
            portal.initiatePortal(this);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
      //  if (collision.gameObject.CompareTag("bas")) // Проверяем тег объекта
        //{
          //  rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Применяем силу прыжка вверх
        //}
    //}

}