using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string MainScene;
    void Start()
    {
        
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(MainScene);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

}
