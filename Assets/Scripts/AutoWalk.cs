using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoWalk : MonoBehaviour {

    public bool canWalk = false;
    public float speed = 10;
    public Text WalkButtonText;
    public float groundHeight = 2;

    public void ToggleWalk()
    {

        if (!canWalk)
        {
            canWalk = true;
            WalkButtonText.text = "Autowalk ON";
        }
        else
        {
            canWalk = false;
            WalkButtonText.text = "Autowalk OFF";
        }
        
    }

    // Update is called once per frame
    void Update () {
        if (canWalk)
        {
            transform.Translate((Vector3.forward * speed) * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, groundHeight, transform.position.z);
        }
    }
}
