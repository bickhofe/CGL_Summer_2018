using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20;
	public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb.velocity = transform.right *speed;
        Destroy(gameObject,5);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D hitInfo) {
		Debug.Log(hitInfo.name);

        
		Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
		if (enemy != null) {
			enemy.TakeDamage(10);
			Debug.Log(hitInfo.transform.name);
            Destroy(gameObject);
		}
	}
}
