using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManageMent : MonoBehaviour
{
    public bool paused;
    public GameObject pausedPanel;
    public GameObject settingsPanel;




    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pausedPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //if we perss escape Key
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // if it is not paused, pause
            // if it is paused already, and isn't showing the settings, continue
            // if it is paused already and is showing settings, unshow settings, don't continue
            if (!paused)
            {
                Pause();
            }
            if (paused)
            {
                if (settingsPanel.active)
                {
                    settingsPanel.SetActive (false);
                }
                else
                {
                    Continue();
                }
            }
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        pausedPanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        paused = false;
        pausedPanel.SetActive(false);


    }
}
