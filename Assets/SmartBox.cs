using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartBox : MonoBehaviour
{
    public CharacterHandler characterHandler;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterHandler = player.GetComponent<CharacterHandler>();
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("e");
          characterHandler.points++;
        }
    }
}
