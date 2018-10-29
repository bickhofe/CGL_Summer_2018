using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStatic : MonoBehaviour
{
    //public CubeGetSet CubeScript;

    // Use this for initialization
    void Start()
    {
        CubeGetSet.health += 200;

        CubeGetSet.health -= 50;
        print("-> " + CubeGetSet.health);

        //CubeGetSet.health += 200;
        //print("-> "+CubeGetSet.health);
    }
}
