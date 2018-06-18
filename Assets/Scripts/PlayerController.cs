using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpForce = 20;
	public CharacterController controller;

	private Vector3 moveDirection;
	public float gravityScale;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		moveDirection = new Vector3(Input.GetAxis("Horizontal")*moveSpeed,moveDirection.y,Input.GetAxis("Vertical")*moveSpeed);
		
		if (controller.isGrounded){
			moveDirection.y = 0f;
			if(Input.GetButtonDown("Jump")) moveDirection.y = jumpForce;
		}
		
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		controller.Move(moveDirection*Time.deltaTime);
	}
}
