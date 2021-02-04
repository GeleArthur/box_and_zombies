using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FollowThis : MonoBehaviour
{
    private Vector3 _position;
    public CinemachineTargetGroup setthecamera;

    private void Start()
    {
        _position = new Vector3(0, 0, 0);

        List<CinemachineTargetGroup.Target> fortheCamera = new List<CinemachineTargetGroup.Target>();
        foreach (var zomby in Game_Mannger.Instance.Zombies)
        {
            var target = new CinemachineTargetGroup.Target {target = zomby.GetComponent<Transform>(), weight = 2};
            fortheCamera.Add(target);
        }

        var surviaor = new CinemachineTargetGroup.Target {target = Game_Mannger.Instance.survivor.transform, weight = 1};
        fortheCamera.Add(surviaor);

        setthecamera.m_Targets = fortheCamera.ToArray();
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
