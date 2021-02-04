using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // singleton stuff
    private static LevelManager _instance;
    public static LevelManager Instance => _instance;

    public int levelindex;
    
    private void Awake()
    {
        // singleton stuff
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int a)
    {
        SceneManager.LoadScene(a);
    }

    public void saveCurrentIndex()
    {
        levelindex = SceneManager.GetActiveScene().buildIndex;
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
    /*public void LoadNextLevel()
    {
        //var index = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(levelindex + 1);
        
        SceneManager.LoadScene(levelindex + 1);
        levelindex = SceneManager.GetActiveScene().buildIndex;
    }*/
    

    
}
