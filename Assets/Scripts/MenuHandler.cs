﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //interacting with scene change
using UnityEngine.UI;//interacting withg GUI elements
using UnityEngine.EventSystems; //control the event (button things)

public class MenuHandler : MonoBehaviour
{

    public GameObject mainMenu, optionsMenu, creditMenu;
    public bool showOptions;
    //public bool showCredits;
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ToggleOptions()
    {
        OptionToggle();
       // CreditToggle();
    }
    /*bool CreditToggle()
    {
        if (showCredits)
            showCredits = false;
        mainMenu.SetActive(true);
        creditMenu.SetActive(false);
        return true;
        */

        bool OptionToggle()
        {
            if (showOptions) //showOptions == true , or showOptions is true
            {
                showOptions = false;
                mainMenu.SetActive(true);
                optionsMenu.SetActive(false);
                return true;
            }
            else
            {
                showOptions = true;
                mainMenu.SetActive(false);
                optionsMenu.SetActive(true);
                return false;
            }
        }
    }
    

