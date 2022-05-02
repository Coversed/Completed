using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public float[] sludgeSpeed = { 2.5f, -2.5f };
    public float distance = 4f;
    public Transform[] sludges;



    private void Update()
    {
        for (int i = 0; i < sludges.Length; i++)
        {
            sludges[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * sludgeSpeed[i]) * distance, Mathf.Sin(Time.time * sludgeSpeed[i]) * distance, 0);

        }
        

        



    }

}
