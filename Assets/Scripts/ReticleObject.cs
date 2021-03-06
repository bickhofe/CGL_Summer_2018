﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class ReticleObject : MonoBehaviour
{
    public GameObject Player;
    public Image RingFill;
    public bool isActive;
    public float waitTime = 3.0f;
    public float resetTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
       // print(isActive);
        
        if (isActive && RingFill.fillAmount < 1) RingFill.fillAmount += 1.0f / waitTime * Time.deltaTime;
        else if (!isActive && RingFill.fillAmount > 0) RingFill.fillAmount -= 1.0f / resetTime * Time.deltaTime;
        else if (isActive && RingFill.fillAmount >= 1)
        {
            //send one message only!
            Player.SendMessage("ObjectSelected", true);
            
            //isActive = false;
            RingFill.fillAmount = 0;
        }
    }
}