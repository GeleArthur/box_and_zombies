using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surviver : MonoBehaviour
{
    private int health = 1000;
    private Transform gun;
    [SerializeField] private LayerMask zombielayer;
    
    private void Awake()
    {
        gun = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(gun.position, gun.forward, out hit , 1000, zombielayer))
        {
            hit.transform.GetComponent<Zombie>().takeDamage(10);
        }
    }
    public void takeDamage(int Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            Debug.Log("Survior is dead");
        }
    }
}
