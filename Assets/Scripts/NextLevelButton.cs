using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void nextlevel()
    {
        if (SceneManager.sceneCountInBuildSettings < LevelManager.Instance.levelindex + 1)
        {
            LevelManager.Instance.LoadScene(LevelManager.Instance.levelindex + 1);
        }
        else
        {
            LevelManager.Instance.LoadScene(0);
        }
            
    }

    public void loadScene(int a)
    {
        LevelManager.Instance.LoadScene(a);
    }
}
