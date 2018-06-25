using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {
    public Vector3[] Ziele;
    //public Transform[] ZieleTrans;
    public float speed = 1;
    int pos = 0;

    void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, Ziele[pos], step);

		Vector3 targetDir = Ziele[pos] - transform.position;
        //float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        //Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);


		if (transform.position == Ziele[pos]) {
			if (pos < Ziele.Length-1) pos++;
			else pos = 0;
		}
    }
}