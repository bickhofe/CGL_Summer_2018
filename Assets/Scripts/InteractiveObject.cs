using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour {

    public UnityEvent overAction;
    public UnityEvent outAction;
    public UnityEvent selectAction;

    public void onOver()
    {
        print("my name is: " + gameObject.name);
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
