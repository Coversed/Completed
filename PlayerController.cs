using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Mover
{
    private SpriteRenderer spriteRenderer;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool isAlive = true;



    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();        
    }
    
    protected override void ReceiveDamage(Damage dmg)
    {
        if(!isAlive)
            return;

        base.ReceiveDamage(dmg);
    }
    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(isAlive)
            UpdateMotor(new Vector3(x, y, 0));
    }

    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinId];
    }
    public void OnLevelUp()
    {
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }
    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
            OnLevelUp();


    }
    public void Heal(int healingAmount)
    {
        if (hitpoint == maxHitpoint)
            return;

        hitpoint += healingAmount;
        if (hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;


        GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);


    }

    private void Update()
    {
        if(hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;
        }


        for (int i = 0; i < hearts.Length; i++)


        {
            if(i < hitpoint)
            {
                hearts[i].sprite = fullHeart;

            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHitpoint) 
            { 
                hearts[i].enabled = true; 
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Respawn()
    {
        maxHitpoint = 5;
        hitpoint = 5;
        Heal(maxHitpoint);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }


}


  







