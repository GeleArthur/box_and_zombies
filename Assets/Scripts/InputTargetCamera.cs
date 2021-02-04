using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputTargetCamera : MonoBehaviour
{
    private Vector3 centerofZombies;
    [SerializeField] private Vector3 InputplusCamera;
    [SerializeField] private float angleofInput;
    [SerializeField] private float cameraRot;

    void Update()
    {
        
        
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        angleofInput = (Mathf.Atan2(input.x, input.z));
        cameraRot =  (Camera.main.transform.rotation.eulerAngles.y+90) * Mathf.Deg2Rad;
        
        InputplusCamera = new Vector3(Mathf.Cos(cameraRot+Mathf.PI + angleofInput), 0, Mathf.Sin(angleofInput + cameraRot)).normalized * 10;
        

        centerofZombies = Vector3.zero;
        foreach (var zomby in Game_Mannger.Instance.Zombies)
        {
            centerofZombies += zomby.transform.position;
        }

        centerofZombies /= Game_Mannger.Instance.Zombies.Count;

        NavMeshHit hit;
        NavMesh.SamplePosition(centerofZombies + InputplusCamera, out hit, 1000, NavMesh.AllAreas);
        
        transform.position = hit.position;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(centerofZombies,centerofZombies+InputplusCamera);
        
        Gizmos.color = Color.red;
        Gizmos.DrawRay(centerofZombies, InputplusCamera);
        
        //Gizmos.DrawLine(Camera.main.transform.position.removeY(),centerofZombies);
        
    }
}
