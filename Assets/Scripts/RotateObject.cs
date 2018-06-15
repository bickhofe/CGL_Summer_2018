using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public bool isActive;
    public Vector3 direction = new Vector3(0,1,0);
    public float speed = 25f;

	// Use this for initialization
	void Start () {
        isActive = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive) transform.Rotate(direction * speed * Time.deltaTime);
	}

    public void SetActive()
    {
        isActive = true;
    }

    public void SetInactive()
    {
        isActive = false;
        transform.eulerAngles = Vector3.zero;
    }
}
