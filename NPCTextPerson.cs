using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPerson : Collidable
{
    public string message;

    public float cooldown = 2.0f;
    private float lastShout;

    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "Player")
        {
            if (Time.time - lastShout > cooldown)

            {
                lastShout = Time.time;
                GameManager.instance.ShowText(message, 17, Color.white, transform.position + new Vector3(0, 1.5f, 0), Vector3.zero, cooldown);
            }
        }

    }
}
