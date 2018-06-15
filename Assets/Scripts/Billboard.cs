using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    public Camera myCamera;

    void Update()
    {
        transform.LookAt(transform.position + myCamera.transform.rotation * Vector3.forward, myCamera.transform.rotation * Vector3.up);
    }
}