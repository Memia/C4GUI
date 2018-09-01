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
    public void Update()
    {

        //if we perss escape Key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else if (paused && settingsPanel.activeSelf)
            {

                {
                    settingsPanel.SetActive(false);
                    pausedPanel.SetActive(true);
                }

            }
            else
            {
                Continue();
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
