using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGetSet : MonoBehaviour
{
    private int _health = 100;

    public int health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;

            //if (value <= 0) _health = 0;
            //else if (value >= 100)_health = 100;
            //else _health = value;  
        }
    }

    //void Start()
    //{
    //    health += 200;
    //    print(health);
    //}

}
