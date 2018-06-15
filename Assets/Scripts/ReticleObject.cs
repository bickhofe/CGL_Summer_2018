using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class ReticleObject : MonoBehaviour
{
    public Image RingFill;
    public bool isActive;
    public float waitTime = 3.0f;
    public float resetTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (isActive && RingFill.fillAmount < 1) RingFill.fillAmount += 1.0f / waitTime * Time.deltaTime;
        else if (!isActive && RingFill.fillAmount > 0) RingFill.fillAmount -= 1.0f / resetTime * Time.deltaTime;
        else if (isActive && RingFill.fillAmount >= 1)
        {
            //send one message only!
            Camera.main.SendMessage("ObjectSelected", true);
            //isActive = false;
            RingFill.fillAmount = 0;
        }
    }
}