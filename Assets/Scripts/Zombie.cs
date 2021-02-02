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
    protected Rigidbody rb;

    float dmgTimer = 0;
    [SerializeField] private LayerMask zombielayer;
    [SerializeField] private LayerMask survivorLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(Player);
        
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 1000);
        
        if (hit.transform.GetComponent<Survivor>() || hit.transform.GetComponent<Zombie>())
        {
            rb.MovePosition(transform.position + transform.forward * MoveSpeed * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(transform.position + new Vector3(1,0,0) * MoveSpeed * Time.deltaTime);
        }
        
        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
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
