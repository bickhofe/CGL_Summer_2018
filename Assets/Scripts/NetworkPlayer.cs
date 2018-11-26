using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour
{
    Vector3 dir;
    public float speed = 1;

    public Transform Ship;
    float rotSpeed = 0;

    //shooting
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        Ship.Rotate(Vector3.forward* rotSpeed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
            //Fire();
        }

    }


    //void Fire()
    //{
    //    // Create the Bullet from the Bullet Prefab
    //    var bullet = (GameObject)Instantiate(
    //        bulletPrefab,
    //        bulletSpawn.position,
    //        bulletSpawn.rotation);

    //    // Add velocity to the bullet
    //    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

    //    // Destroy the bullet after 2 seconds
    //    Destroy(bullet, 2.0f);
    //}

    [Command]
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }


    public override void OnStartLocalPlayer()
    {
        rotSpeed = 10;
    }
}
