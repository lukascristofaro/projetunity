using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public static bool isDead = false;

    public GameObject pauseMenuUI;

    public static DeathMenu instance;

    public string MainScene;



    void Awake()
    {
        pauseMenuUI.SetActive(false);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void DeathInput()
    {
        instance.Paused();

    }

    public void Paused()
    {
        Cursor.lockState = CursorLockMode.None;

        Debug.Log("Died");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isDead = true;
    }

    public void Resume()
    {
        Debug.Log("Resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isDead = false;
    }

    public void GetMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void GetMainScene()
    {
        SceneManager.LoadScene(MainScene);
    }
}