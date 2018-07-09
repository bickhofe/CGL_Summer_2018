using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {

    public CreateTargets TargetScript;
    public Transform target;
    public float speed = 1;
    public float rotateSpeed = 1;

    // Use this for initialization
    void Start () {
        TargetScript = GameObject.Find("Main").GetComponent<CreateTargets>();

        //kill after 10 sek.
        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {

        if (target != null)
        {
            //aim
            Vector3 targetDir;
            targetDir = target.position - transform.position;

            float step = rotateSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }

        //move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            TargetScript.AirTargets.Remove(target); //remove from list
            Destroy(other.gameObject); //remove game object
            Destroy(gameObject); //remove rocket
            print("hit");
        }
    }
}
