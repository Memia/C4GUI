using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel : MonoBehaviour
{
    public GameObject levelUpPanel;
    [Header("Stats")]
    public Text point;
    public Text charisma, strength, dexterity, constitution, wisdom, intellicence;
    [Header("Reference")]
    public CharacterHandler characterHandler;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        //Grabbing the player game object
        player = GameObject.FindGameObjectWithTag("Player");
        //Refercing the script
        characterHandler = player.GetComponent<CharacterHandler>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            levelUpPanel.SetActive(true);
            Time.timeScale = 0;
        }
        #region Stat Display
        charisma.text = characterHandler.charisma.ToString();
        strength.text = characterHandler.strength.ToString();
        dexterity.text = characterHandler.dexterity.ToString();
        constitution.text = characterHandler.constitution.ToString();
        wisdom.text = characterHandler.wisdom.ToString();
        intellicence.text = characterHandler.intelligence.ToString();
        point.text = characterHandler.points.ToString();
        #endregion
    }
}
