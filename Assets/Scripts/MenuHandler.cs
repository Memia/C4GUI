using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //interacting with scene change
using UnityEngine.UI;//interacting withg GUI elements
using UnityEngine.EventSystems; //control the event (button things)

public class MenuHandler : MonoBehaviour
{
    #region Variables
    public GameObject mainMenu, optionsMenu, creditMenu;
    public bool showOptions;
    //public bool showCredits;
    public Slider volSlider, brightSlider, ambSlider;
    public AudioSource mainAudio;
    public Light dirLight;
    public Vector2[] res = new Vector2[8];
    public int resIndex;
    public bool isFullScreen;
    public Dropdown resDropdown;
    #endregion
    private void Start()
    {

        mainAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        dirLight = GameObject.FindGameObjectWithTag("DirLight").GetComponent<Light>();



    }
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
        return true;*/


    bool OptionToggle()
    {
        if (showOptions) //showOptions == true , or showOptions is true
        {
            showOptions = false;
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            return false;
        }
        else
        {
            showOptions = true;
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            volSlider = GameObject.Find("Volume_Slider").GetComponent<Slider>();
            volSlider.value = mainAudio.volume;//slider dot starts where volume amount is, but won't affect the volume
            brightSlider = GameObject.Find("Brightness_Slider").GetComponent<Slider>();
            brightSlider.value = dirLight.intensity;
            ambSlider = GameObject.Find("Ambience_Slider").GetComponent<Slider>();
            ambSlider.value = RenderSettings.ambientIntensity;
            resDropdown = GameObject.Find("Resolution").GetComponent<Dropdown>();
            resDropdown.value = resIndex;
            return true;
        }
    }
    public void Volume()
    {
        //volume is set to where slider is moved to
        mainAudio.volume = volSlider.value;
    }
    public void Brightness()
    {
        dirLight.intensity = brightSlider.value;

    }
    public void Ambience()
    {
        RenderSettings.ambientIntensity = ambSlider.value;
    }
    public void Resolution()
    {
        resIndex = resDropdown.value;
        Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullScreen);
    }
}





