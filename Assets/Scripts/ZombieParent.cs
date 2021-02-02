using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieParent : MonoBehaviour
{
    float Health = 100;


    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
