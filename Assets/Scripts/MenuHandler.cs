using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //interacting with scene change
using UnityEngine.UI;//interacting withg GUI elements
using UnityEngine.EventSystems; //control the event (button things)

public class MenuHandler : MonoBehaviour
{

    #region Variables
    [Header("OPTIONS")]
    public bool showOptions;
    [Header("Keys")]
    public KeyCode holdingKey;
    public KeyCode forward, backward, left, right, jump, crouch, sprint, interact;
    [Header("Preferences")]

    [Header("References")]
    public AudioSource mainAudio;
    public Slider volSlider, brightSlider, ambSlider;
    public Light dirLight;
    public Vector2[] res = new Vector2[8];
    public int resIndex;
    public bool isFullScreen;
    public Dropdown resDropdown;
    [Header("Leybind References")]
    public Text forwardText;
    public Text backwardText, leftText, rightText, jumpText, crouchText, sprintText, interactText;
    public GameObject mainMenu, optionsMenu, creditMenu;

    //public bool showCredits;


    #endregion
    private void Start()
    {

        mainAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        dirLight = GameObject.FindGameObjectWithTag("DirLight").GetComponent<Light>();

        #region SetUp Keys
        //set out keys to the preset keys we may have saved, else set the keys to default.
        /*forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
        crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "LeftControl"));
        sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E"));
        */

        #endregion
        #region Settings

        #endregion
        Resolution[] resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {
            print(res.width + "x" + res.height);
        }
        Screen.SetResolution(resolutions[0].width, resolutions[0].height, true);
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
    public void Save()
    {                         //file name, data
        PlayerPrefs.SetString("Forward", forward.ToString());
        PlayerPrefs.SetString("Backward", backward.ToString());
        PlayerPrefs.SetString("Left", left.ToString());
        PlayerPrefs.SetString("Right", right.ToString());
        PlayerPrefs.SetString("Jump", jump.ToString());
        PlayerPrefs.SetString("Crouch", crouch.ToString());
        PlayerPrefs.SetString("Sprint", sprint.ToString());
        PlayerPrefs.SetString("Interact", interact.ToString());
        PlayerPrefs.SetFloat("Volume", volSlider.value);
        PlayerPrefs.SetString("FullScreen", isFullScreen.ToString());
    }
    void OnGUI()
    {
        Event e = Event.current;
        if (forward == KeyCode.None)
        {
            Debug.Log("KeyCode: " + e.keyCode);
            if (e.keyCode != KeyCode.None)
            {
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    forward = e.keyCode;
                    holdingKey = KeyCode.None;
                    forwardText.text = forward.ToString();
                }
                else
                {
                    forward = holdingKey;
                    holdingKey = KeyCode.None;
                    forwardText.text = forward.ToString();
                }
            }


        }
    }
    public void Forward()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
        {
            holdingKey = forward;
            forward = KeyCode.None;
            forwardText.text = forward.ToString();
        }
    }
}


