using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject: MonoBehaviour {

    public float minDistance = 5;

    public void Teleport()
    {
        print("Teleport");
        Vector3 direction = Random.onUnitSphere;
        direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
        float distance = minDistance * Random.value + 1.5f;
        transform.localPosition = direction * distance;
    }
}
