using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThis : MonoBehaviour
{
    private Vector3 _position;

    private void Start()
    {
        _position = new Vector3(0, 0, 0);
    }

      
    void Update()
    {
        Vector3 centerofZombies = Vector3.zero;
        foreach (var zomby in Game_Mannger.Instance.Zombies)
        {
            centerofZombies += zomby.transform.position;
        }

        centerofZombies /= Game_Mannger.Instance.Zombies.Count;
        
        //_position.z = centerofZombies.z -5;
        transform.position = centerofZombies;
    }
}
