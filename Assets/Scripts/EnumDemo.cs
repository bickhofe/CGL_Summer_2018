using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumDemo : MonoBehaviour
{
    public enum Animal { Elephant, Ape, Tiger, Lion, Bear };

    //[Header("Animals")]
    [SerializeField]
    public Animal animal;

    //[Space]

    //[Header ("Stuff")]
    //[Range(0, 1000)]
    //public float distance = 0;

    //[HideInInspector]
    //public int score;

    //[SerializeField]
    //private int damage;

    void Start()
    {

    }
}
