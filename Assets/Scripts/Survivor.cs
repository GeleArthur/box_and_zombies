using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Survivor : MonoBehaviour
{
    [SerializeField] private LayerMask zombielayer;
    [SerializeField] private List<Zombie> _zombiesIsee;
    [SerializeField] private Animator gun;
    [SerializeField] private Transform[] PointToRunTo;
    [SerializeField] private int AtPoint = 0;
    [SerializeField] private float TimeToMove = 2f;
    [SerializeField] private bool canGetHit = true;

    private void Awake()
    {
        StartCoroutine(ShootZombieEnum());
    }

    IEnumerator ShootZombieEnum()
    {
        while (true)
        {
            yield return new WaitUntil(() => canGetHit);
            yield return new WaitForSeconds(0.1f);
            Shootzombie();
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
    

    void Shootzombie()
    {
        Zombie zom = zombieIsee();
        if(zom == null) return;
        gun.SetTrigger("shoot");

        var position = zom.transform.position;
        transform.LookAt(new Vector3(position.x,transform.position.y,position.z));
        
        zom.takeDamage(1);

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
            StartCoroutine(RunAway(transform.position, PointToRunTo[AtPoint].position));
            AtPoint++;
        }
    }

    private void OnDrawGizmos()
    {
        if(Game_Mannger.Instance == null) return;

    }
}
