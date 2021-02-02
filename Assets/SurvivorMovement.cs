using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorMovement : MonoBehaviour
{
    [SerializeField] GameObject Teleports;
    float cd = 10;
    Transform[] children;
    // Start is called before the first frame update
    void Start()
    {
        children = gameObject.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cd <= 0)
        {
            
            int random = Random.Range(0, children.Length);
            Vector3 newPosition = Teleports.transform.GetChild(random).position;
            newPosition.y = 1f;

            
            newPosition.y = 1f;
            transform.transform.position = newPosition;
            cd = 10;
        }
        else
        {
            cd -= Time.deltaTime;
        }
        
    }
}
