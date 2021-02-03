using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLeader : Zombie
{
    Rigidbody rb;
    [SerializeField]
    float MoveSpeed = 4;
    float x;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Vertical");
        z = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(x,0,z) * MoveSpeed * Time.deltaTime);
        
    }

}
