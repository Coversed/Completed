using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damagage struct
    public int[] damagePoint = { 0, 1 , 3 , 5 , 7 , 9 , 11 , 13 };
    public float[] pushforce = { 0f, 2.0f, 2.2f, 2.5f, 3f, 3.2f, 3.6f, 4f };

    // Upgrade
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;

    // Swing weapon
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        //Fighter tag is used to determine whether or not the weapon can collide with a target (this prevents npc deaths)
        if(coll.tag == "Fighter")
        {
            //Prevents weapon collider from interacting with player collider
            if (coll.name == "Player")
                return;

            // Create a new damage object, then we'll send it to fighter we've hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushforce[weaponLevel]
            };

            coll.SendMessage("ReceiveDamage", dmg);

           
            
           

        }


    }

    private void Swing()
    {
        anim.SetTrigger("Swing");

    }


    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

        // Change Stats
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }

    public void Respawn()
    {
        weaponLevel = 0;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

    }
}
