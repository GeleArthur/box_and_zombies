using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Mannger : MonoBehaviour
{
    // singleton stuff
    private static Game_Mannger _instance;
    public static Game_Mannger Instance => _instance;
    
    // Zombie data
    public List<Zombie> Zombies;
    public Survivor survivor;

    private void Awake()
    {
        // singleton stuff
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        Zombies = new List<Zombie>();
        
    }
}
