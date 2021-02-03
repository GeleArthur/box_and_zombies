using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, speed*Time.deltaTime);
    }
}
