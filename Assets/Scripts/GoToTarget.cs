using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToTarget : MonoBehaviour {

    public Transform Target;
    public float targetDist = .5f;
    public bool canWalk = false;
    public float speed = 10;
    public float groundHeight = 1;

    // Update is called once per frame
    void Update () {
        float dist = Vector3.Distance(transform.position, Target.position);
        transform.LookAt(Target);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

        if (canWalk && dist > targetDist)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, groundHeight, transform.position.z);   
        }
    }
}
