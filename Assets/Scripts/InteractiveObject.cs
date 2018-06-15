using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour {

    public UnityEvent overAction;
    public UnityEvent outAction;
    public UnityEvent selectAction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onOver()
    {
        print("may name is: " + gameObject.name);
        if (overAction != null) overAction.Invoke();
    }

    public void onOut()
    {
        print("Goodbye!");
        if (outAction != null) outAction.Invoke();
    }

    public void select()
    {
        print("action!");
        if (selectAction != null) selectAction.Invoke();
    }
}
