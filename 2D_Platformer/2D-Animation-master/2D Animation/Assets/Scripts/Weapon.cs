using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform firePoint;
    public GameObject bulletPrefab;
	public GameObject impactFX;
	public LineRenderer line;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")){
			Shoot();
            //ShootRaycast();
		}
	}

	void Shoot(){
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}

    void ShootRaycast()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
		if (hitInfo){
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            
			if (enemy != null)
            {
                enemy.TakeDamage(10);
            }

			line.SetPosition(0,firePoint.position);
            line.SetPosition(1, hitInfo.point);

            Instantiate(impactFX, hitInfo.point, Quaternion.identity);
			Debug.Log(hitInfo.transform.name);
		} else {
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, firePoint.position + firePoint.right*100);
		}

		line.enabled = true;
		
		//yield return 0;

		//line.enabled = false;
    }
}
