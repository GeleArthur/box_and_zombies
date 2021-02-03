using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void LoadScene(string name)
    {
       
        SceneManager.LoadScene(name);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
