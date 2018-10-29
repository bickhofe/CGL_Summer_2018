using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyCube : MonoBehaviour
{
    public static float health; 
    public static int cubeCount = 0;

    void Start()
    {
        print("cube");
        //for instances of the cube
        cubeCount++;
    }

    //cube class
    public MyCube()
    {
        //cubeCount++;
        //print(cubeCount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health++;
            print("health: " + health);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("CGLStaticsOtherScene", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("CGLStatics", LoadSceneMode.Single);
        }
    }


}
