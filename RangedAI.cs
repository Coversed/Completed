using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAI : MonoBehaviour
{



    public float speed;
 

    public Transform playerTransform;
    public float chaseRange;

    public float attackRange;
    public int damage = 1;
    private float lastAttackTime;
    public float attackDelay;

    public GameObject projectile;
    public float orbForce;
      void Start()
    {
        playerTransform = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks to see if player is within range
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if(distanceToPlayer < attackRange)
        {
            //Turns towards the target
            Vector3 targetDir = playerTransform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

            // Checks to see if it's time to attack
            if(Time.time > lastAttackTime + attackDelay)
            {
                //Raycast to see if we have line of sight to the target
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);
                // Check to see if we hit anything and return what it was
                if(hit.transform == playerTransform)
                {
                    //Cast hits the player - fires projectile
                    GameObject newOrb = Instantiate(projectile, transform.position, transform.rotation);
                    newOrb.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, orbForce));
                    lastAttackTime = Time.time;

                }
            }
        }
    }

}
