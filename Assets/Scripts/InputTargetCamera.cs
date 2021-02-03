using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputTargetCamera : MonoBehaviour
{
    private Vector3 centerofZombies;
    private Vector3 InputplusCamera;
    
    void Update()
    {
        
        
        Vector3 input = new Vector3(Input.GetAxis("Horizontal")*10, 0, Input.GetAxis("Vertical")*10);
        /*var angleofInput = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg;
        float cameraRot =  Camera.main.transform.rotation.eulerAngles.y;

        InputplusCamera =
            new Vector3(input.x *(Mathf.Cos(cameraRot)*10), 0, input.z * (Mathf.Sin(angleofInput + cameraRot)*10));*/

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
        Gizmos.DrawLine(centerofZombies,centerofZombies+InputplusCamera);
        
        Gizmos.color = Color.red;
        Gizmos.DrawRay(centerofZombies, InputplusCamera);
        
        //Gizmos.DrawLine(Camera.main.transform.position.removeY(),centerofZombies);
        
    }
}
