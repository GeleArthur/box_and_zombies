using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    
    void FixedUpdate()
    {
        transform.position += (transform.forward*speed *Time.fixedDeltaTime);
        if (Physics.Raycast(transform.position, transform.forward, out var hit ,0.5f))
        {
            var zomy = hit.transform.GetComponent<Zombie>();
            if(zomy != null) zomy.takeDamage(1);
            Destroy(gameObject);
        }
    }
}
