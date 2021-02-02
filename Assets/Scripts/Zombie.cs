using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    public float health = 100;
    [SerializeField]
    public Transform Player;
    [SerializeField]
    float MoveSpeed = 4;
    [SerializeField]
    float MaxDist = 10;
    [SerializeField]
    float MinDist = 3;
    Rigidbody rb;

    float dmgTimer = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(Player);

       
            
           

             rb.MovePosition(transform.position + transform.forward * MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, Player.position) <= MinDist )
            {
            Debug.Log("hello");
                if (dmgTimer <= 0)
                {
                    Player.GetComponent<Survivor>().takeDamage(100);
                    dmgTimer = 2;
                }
                else
                {
                    dmgTimer -= Time.deltaTime;
                }
                
            }

        
        
    }


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
