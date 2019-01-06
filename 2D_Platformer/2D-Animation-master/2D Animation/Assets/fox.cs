using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fox : MonoBehaviour {

	public Rigidbody2D rb;
	public float jump = 25;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) rb.AddForce(transform.up * jump);
	}
}
