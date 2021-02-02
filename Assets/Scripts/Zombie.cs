using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    
    public float health = 100;
  
    public void takeDamage(int damage)
    {

        Debug.Log("got hit for "+ damage);

        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
