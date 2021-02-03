using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Survivor : MonoBehaviour
{
    private int health = 1000;
    private Transform gun;
    [SerializeField] private LayerMask zombielayer;
    [SerializeField] private List<Zombie> _zombiesIsee;

    private void Awake()
    {
        gun = transform.GetChild(0);
        //StartCoroutine(ShootZombieEnum());
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
            yield return new WaitForSeconds(0.1f);
            Shootzombie();
            yield return new WaitForSeconds(3f);
        }
    }
    

    void Shootzombie()
    {
        Zombie zom = zombieIsee();
        if(zom == null) return;
        Debug.Log("shoot " + zom.name);

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
    
    public void takeDamage(int Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            Debug.Log("Survior is dead");
        }
    }

    private void OnDrawGizmos()
    {
        if(Game_Mannger.Instance == null) return;

    }
}
