using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    // Logic
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        // Checks to see if the player is hitting the collectable not the collider of an enemy/ wall
        if (coll.name == "Player")
            OnCollect();
    }
    protected virtual void OnCollect()
    {
        collected = true;
    }

}