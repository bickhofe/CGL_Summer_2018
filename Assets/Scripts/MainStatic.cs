using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStatic : MonoBehaviour
{
    public CubeGetSet CubeScript;

    // Use this for initialization
    void Start()
    {
        CubeScript.health += 200;
        print("-> " + CubeScript.health);

        //CubeGetSet.health += 200;
        //print("-> "+CubeGetSet.health);
    }
}
