using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        Debug.Log("Pause");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        InPause = true;
    }

    void Resume()
    {
        Debug.Log("Resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        InPause = false;
    }
}