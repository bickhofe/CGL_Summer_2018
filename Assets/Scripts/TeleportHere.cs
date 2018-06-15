using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHere : MonoBehaviour {

    public Camera myCamera;

    public void SetNewCameraPosition()
    {
        myCamera.transform.position = transform.position;
    }
}
