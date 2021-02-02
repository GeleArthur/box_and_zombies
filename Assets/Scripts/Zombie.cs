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
    float MinDist = 5;
    


    
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
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
