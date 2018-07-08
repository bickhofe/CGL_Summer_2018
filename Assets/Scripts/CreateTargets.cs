using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTargets : MonoBehaviour {

    public Transform targetPrefab;
    public List<Transform> Targets = new List<Transform>();
    public List<Transform> AirTargets = new List<Transform>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Transform newTarget = Instantiate(targetPrefab, new Vector3(Random.Range(-10.0f, 10.0f), .25f, Random.Range(-10.0f, 10.0f)), Quaternion.identity);
            Targets.Add(newTarget);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Transform newAirTarget = Instantiate(targetPrefab, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(5f, 10.0f), Random.Range(-10.0f, 10.0f)), Quaternion.identity);
            AirTargets.Add(newAirTarget);
        }
    }
}
