using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputTargetCamera : MonoBehaviour
{
    private Vector3 centerofZombies;
    private Vector3 input;
    
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal")*10, 0, Input.GetAxis("Vertical")*10);

        centerofZombies = Vector3.zero;
        foreach (var zomby in Game_Mannger.Instance.Zombies)
        {
            centerofZombies += zomby.transform.position;
        }

        centerofZombies /= Game_Mannger.Instance.Zombies.Count;

        NavMeshHit hit;
        NavMesh.SamplePosition(centerofZombies + input, out hit, 1000, NavMesh.AllAreas);
        
        transform.position = hit.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(centerofZombies,centerofZombies+input);
    }
}
