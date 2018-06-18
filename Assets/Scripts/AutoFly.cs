using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoFly : MonoBehaviour {

    public Transform VRCam;
    public bool canFly = false;
    public float speed = 10;
    public Text FlyButtonText;
    public float minHeight = 0.5f;
    public float maxHeight = 10f;

	// Use this for initialization
	void Start () {
		
	}

    public void ToggleFly()
    {

        if (!canFly)
        {
            canFly = true;
            FlyButtonText.text = "Autofly ON";
        }
        else
        {
            canFly = false;
            FlyButtonText.text = "Autofly OFF";
        }
        
    }

    // Update is called once per frame
    void Update () {
        if (canFly)
        {
            transform.Translate((VRCam.forward * speed) * Time.deltaTime);

            //limit height
            if (transform.position.y < minHeight) transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
            else if (transform.position.y > maxHeight) transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
    }
}
