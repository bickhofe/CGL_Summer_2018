using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHere : MonoBehaviour {

    public GameObject Player;

    public void SetNewCameraPosition()
    {
        Player.transform.position = transform.position;
    }
}
