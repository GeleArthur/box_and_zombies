using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThis : MonoBehaviour
{
    private Vector3 _position;
   [SerializeField] private Transform takePosition;

    private void Start()
    {
        _position = new Vector3(0, 0, 0);
    }

      
    void Update()
    {
        _position.z = takePosition.position.z -5;
        transform.position = _position;
    }
}
