using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calulator : MonoBehaviour
{

    public static float Sum(float numA, float numB)
    {
        return (numA + numB);
    }

    public static float Sub(float numA, float numB)
    {
        return (numA - numB);
    }

    public static float Multi(float numA, float numB)
    {
        return (numA * numB);
    }

    public static float Div(float numA, float numB)
    {
        return (numA / numB);
    }
}
