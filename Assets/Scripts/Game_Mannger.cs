using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Mannger : MonoBehaviour
{
    // singleton stuff
    private static Game_Mannger _instance;
    public static Game_Mannger Instance => _instance;
    
    [Header("world data")]
    // Zombie data
    public List<Zombie> Zombies;
    public Survivor survivor;
    
    [Header("Holders")]
    public GameObject ZombieHolder;



    private void Awake()
    {
        // singleton stuff
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        if (ZombieHolder == null) ZombieHolder = new GameObject("ZombieHolder");
    }

    private void Start()
    {
        Zombies = new List<Zombie>();
        Zombies.AddRange(FindObjectsOfType<Zombie>());
        foreach (Zombie zomby in Zombies)
        {
            zomby.transform.parent = ZombieHolder.transform;
        }
        
        survivor = FindObjectOfType<Survivor>();

        if (survivor == null)
        {
            // spawn survior
        }
    }

    public void removeZombieFromList(Zombie zoms)
    {
        Zombies.Remove(zoms);
    }
}
