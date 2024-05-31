using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausemenu : MonoBehaviour
{
    public static bool InPause = false;

    public GameObject pauseMenuUI;

    public static Pausemenu instance;



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

    public static void PauseInput()
    {
        if (InPause)
        {
            instance.Resume();
        }
        else
        {
            instance.Paused();
        }
    }

    void Paused()
    {
        Cursor.lockState = CursorLockMode.None;

        Debug.Log("Pause");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        InPause = true;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        InPause = false;
    }

    public void GetMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}