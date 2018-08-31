using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class KeyBindScript : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    [Header("Keys")]
    public Text up, down, left, right, jump, crouch, sprint;
    private GameObject curKey;
    private Color32 normal = new Color32(39, 33, 33, 22);
    private Color32 selected = new Color32(33, 55, 77, 77);

    [Header("OPTIONS")]
    public bool showOptions;
    [Header("References")]
    public AudioSource mainAudio;
    public Slider volSlider, brightSlider, ambSlider;
    public Light dirLight;
    public Vector2[] res = new Vector2[8];
    public int resIndex;
    public bool isFullScreen;
    public Dropdown resDropdown;
    [Header("Leybind References")]
    public GameObject mainMenu, optionsMenu, creditMenu;


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
void Start()
    {
   // mainAudio = GameObject.Find("MainMusic").GetComponent<AudioSource>();
    //dirLight = GameObject.Find("DirLight").GetComponent<Light>();
      //  mainAudio.volume = PlayerPrefs.GetFloat("Volume", 1);

        keys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Up","W")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump","Space")));
        keys.Add("Crouch", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "C")));
        keys.Add("Sprint", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift")));
        
        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        jump.text = keys["Jump"].ToString();
        crouch.text = keys["Crouch"].ToString();
        sprint.text = keys["Sprint"].ToString();

        Resolution[] resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {
            print(res.width + "x" + res.height);
        }
        Screen.SetResolution(resolutions[0].width, resolutions[0].height, true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys["Up"]))
        { }
    }
    private void OnGUI()
    {
        if (curKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[curKey.name] = e.keyCode;
                curKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                curKey.GetComponent<Image>().color = normal;
                curKey = null;

            }
        }
    }
    public void ChangeKey(GameObject clicked)
    {
        if (curKey != null)
        {
            curKey.GetComponent<Image>().color = normal;
        }
        curKey = clicked;

      //  PlayerPrefs.SetString("FullScreen", isFullScreen.ToString());

    }
    public void SaveKeys()
    {
        PlayerPrefs.SetFloat("Volume", volSlider.value);

        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
     //  curKey.GetComponent<Image>().color = selected;
    }
    public void ToggleOptions()
    {
        OptionToggle();
        // CreditToggle();
    }
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
           // brightSlider = GameObject.Find("Brightness_Slider").GetComponent<Slider>();
           // brightSlider.value = dirLight.intensity;
           // ambSlider = GameObject.Find("Ambience_Slider").GetComponent<Slider>();
          //  ambSlider.value = RenderSettings.ambientIntensity;
          //  resDropdown = GameObject.Find("Resolution").GetComponent<Dropdown>();
          //  resDropdown.value = resIndex;
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
