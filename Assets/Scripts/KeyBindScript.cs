using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyBindScript : MonoBehaviour
{
    public Slider volSlider, brightSlider, ambSlider;
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text up, down, left, right, jump, crouch, sprint;
    private GameObject curKey;
    private Color32 normal = new Color32(39, 33, 33, 22);
    private Color32 selected = new Color32(33, 55, 77, 77);
    // Use this for initialization

    void Start()
    {
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

        volSlider.value = PlayerPrefs.GetFloat("volume", 1);

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
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
      //  curKey.GetComponent<Image>().color = selected;
        PlayerPrefs.SetFloat("Volume", volSlider.value);
    }
}
