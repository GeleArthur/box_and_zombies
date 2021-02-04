using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Survivor : MonoBehaviour
{
    [SerializeField] private LayerMask zombielayer;
    [SerializeField] private List<Zombie> _zombiesIsee;
    [SerializeField] private Animator gun;
    [SerializeField] private pointAndCamera[] PointToRunTo;
    [SerializeField] private int AtPoint = 0;
    [SerializeField] private float TimeToMove = 2f;
    [SerializeField] private bool canGetHit = true;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private CinemachineVirtualCamera cinecamera;

    [Serializable]
    class pointAndCamera
    {
        public Transform point;
        public Vector3 cameraAngle;
    }
    
    private void Awake()
    {
        StartCoroutine(ShootZombieEnum());
    }

    private void Update()
    {
        var centerofZombies = Vector3.zero;
        foreach (var zomby in Game_Mannger.Instance.Zombies)
        {
            centerofZombies += zomby.transform.position;
        }

        centerofZombies /= Game_Mannger.Instance.Zombies.Count;
        //transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(centerofZombies.removeY()),0.1f );
        transform.LookAt(centerofZombies.removeY());
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
    }

    IEnumerator ShootZombieEnum()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Shootzombie();
            yield return new WaitForSeconds(0.1f);
            Shootzombie();
            yield return new WaitForSeconds(0.1f);
            Shootzombie();
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator RunAway(Vector3 orgin, Vector3 target)
    {
        float elapsedTime = 0;
        
        while (transform.position != target)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(orgin, target, 1/TimeToMove*elapsedTime);
            yield return null;
        }

        canGetHit = true;
        yield return null;
    }

    IEnumerator ChangeCamera(Vector3 target)
    {
        float elapsedTime = 0;
        var cinemachineTransposer = cinecamera.GetCinemachineComponent<CinemachineTransposer>();
        Vector3 ori = cinemachineTransposer.m_FollowOffset;
        
        while (elapsedTime < TimeToMove)
        {
            elapsedTime += Time.deltaTime;
            cinemachineTransposer.m_FollowOffset = Vector3.Lerp(ori, target, 1/TimeToMove*elapsedTime);
            yield return null;
        }
        
        yield return null;
    }
    

    void Shootzombie()
    {
        Zombie zom = zombieIsee();
        if(zom == null) return;
        gun.SetTrigger("shoot");

        var position = zom.transform.position;
        transform.LookAt(new Vector3(position.x,transform.position.y,position.z));

        var bullet = Instantiate(bulletPrefab,bulletSpawn.position,Quaternion.identity);
        bullet.transform.LookAt(zom.transform);
        //bullet.transform.position = bulletSpawn.position;

    }
    

    private Zombie zombieIsee()
    {
        _zombiesIsee = new List<Zombie>();
        Zombie closed = null;
        float dist = Single.PositiveInfinity;
        for (int i = 0; i < Game_Mannger.Instance.Zombies.Count; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Game_Mannger.Instance.Zombies[i].transform.position-transform.position, out hit , 1000))
            {
                if (1 << hit.transform.gameObject.layer == zombielayer)
                {
                    _zombiesIsee.Add(hit.transform.GetComponent<Zombie>());
                    if (dist > hit.distance)
                        closed = hit.transform.GetComponent<Zombie>();
                }
            }
        }

        return closed;
    }
    
    public void takeDamage()
    {
        if (canGetHit)
        {
            canGetHit = false;
            var position = PointToRunTo[AtPoint].point.position;
            //cinecamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = PointToRunTo[AtPoint].cameraAngle;
            
            position.y = 1.75f;
            StartCoroutine(RunAway(transform.position, position));
            StartCoroutine(ChangeCamera(PointToRunTo[AtPoint].cameraAngle));
            AtPoint++;
        }
    }

    private void OnDrawGizmos()
    {
        if(Game_Mannger.Instance == null) return;

        for (int i = 0; i < Game_Mannger.Instance.Zombies.Count; i++)
        {
            Gizmos.DrawRay(transform.position,Game_Mannger.Instance.Zombies[i].transform.position-transform.position);
        }
    }
}
