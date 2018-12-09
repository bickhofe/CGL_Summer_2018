using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int damage = 100;
	// Use this for initialization
	void Start () {
		
	}

	public void TakeDamage (int damageAmmount) {
        damage -= damageAmmount;
		if (damage <= 0) Die();
	}

	void Die(){
		Destroy(gameObject);
	}
}
