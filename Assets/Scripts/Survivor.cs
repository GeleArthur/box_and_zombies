using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : MonoBehaviour
{
    private int health = 1000;
    private Transform gun;
    [SerializeField] private LayerMask zombielayer;

    private void Awake()
    {
        gun = GetComponentInChildren<Transform>();
    }

    private void Update()
    {
        List<Zombie> zombiethatIWillShoot = zombieIsee();
    }

    private List<Zombie> zombieIsee()
    {
        List<Zombie> _zombiesIsee = new List<Zombie>();
        for (int i = 0; i < Game_Mannger.Instance.Zombies.Count; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(gun.position, Game_Mannger.Instance.Zombies[i].transform.position-transform.position, out hit , 1000))
            {
                if(1<<hit.transform.gameObject.layer == zombielayer )
                    _zombiesIsee.Add(hit.transform.GetComponent<Zombie>());
            }
            
        }

        return _zombiesIsee;
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
        List<Zombie> zombiethatIWillShoot = zombieIsee();

        for (int i = 0; i < zombiethatIWillShoot.Count; i++)
        {
            Gizmos.DrawLine(transform.position,zombiethatIWillShoot[i].transform.position);
        }
    }
}
