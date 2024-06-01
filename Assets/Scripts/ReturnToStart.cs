using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStart : MonoBehaviour
{
    public Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tilemap2Collider")) // Проверяем столкновение с объектом, имеющим тег "Tilemap2Collider"
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}
