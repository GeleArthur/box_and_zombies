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
    [SerializeField] private Material black;
    [SerializeField] private Material red;

    private void Awake()
    {
        gun = transform.GetChild(0);
        StartCoroutine(ShootZombie());
    }

    private void Update()
    {
        List<Zombie> zombiethatIWillShoot = zombieIsee();
        if(zombiethatIWillShoot.Count != 0)
            shootzombie(zombiethatIWillShoot[0]);
    }

    IEnumerator ShootZombie()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            
        }
    }
    

    void shootzombie(Zombie zom)
    {
        gun.GetComponent<MeshRenderer>().material = black;
        var position = zom.transform.position;
        transform.LookAt(new Vector3(position.x,transform.position.y,position.z));

        if (Random.Range(0, 100) > 90)
        {
            gun.GetComponent<MeshRenderer>().material = red;
            zom.takeDamage(1);
        }
        
    }
    

    private List<Zombie> zombieIsee()
    {
        List<Zombie> _zombiesIsee = new List<Zombie>();
        for (int i = 0; i < Game_Mannger.Instance.Zombies.Count; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(gun.position, Game_Mannger.Instance.Zombies[i].transform.position-gun.position, out hit , 1000))
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
            Gizmos.DrawLine(gun.position,zombiethatIWillShoot[i].transform.position);
        }
    }
}
