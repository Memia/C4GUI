﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;
    public int amount = 1;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ("" + amount);
    }
    public void TaskOnClick()
    {
        amount++;
        Debug.Log(amount);
    }
    void Memes()
    { }
}
