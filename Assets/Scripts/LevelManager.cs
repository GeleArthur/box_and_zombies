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
    
    
    private int loadedSceneIndex = 0;

    private void Awake()
    {
        // singleton stuff
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextScene()
    {
        LoadScene(loadedSceneIndex+1);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        loadedSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadScene(int index)
    {
        loadedSceneIndex = index;
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
