using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScripts : MonoBehaviour
{
    public Gamemodes Gamemode;
    public SpeedsPlayer Speed;
    public bool gravity;
    public int State;

    public void initiatePortal(Movement movement)
    {
        movement.ChangeThoughPortal(Gamemode, Speed, gravity ? 1 : -1, State, transform.position.y);
    }
}
