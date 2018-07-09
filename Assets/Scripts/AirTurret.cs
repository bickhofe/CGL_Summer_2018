using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTurret : MonoBehaviour {

    public CreateTargets TargetScript;
    public float speed = 2;
    bool canFire = true;
    Transform curTarget;
    public Transform Rocket;

    private void Start()
    {
        InvokeRepeating("TryToFire", 0, 1f);
    }

    void TryToFire()
    {
        if (canFire)
        {
            FireRocket(curTarget);
            print("fire");
        } else
        {
            print("no air target");
        }
    }

    void Update()
    {
        MoveAirTurret();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 100.0f))
        {
            if (hit.transform != curTarget)
            {
                curTarget = hit.transform;
                canFire = true;
            }
        } else
        {
            canFire = false;
            curTarget = null;
        }

        //debug only
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    
    void MoveAirTurret()
    {
        if (GetNextAirTarget() != null)
        {
            //aim
            Vector3 targetDir;
            targetDir = GetNextAirTarget().position - transform.position;

            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    Transform GetNextAirTarget()
    {
        Transform tar = null;
        float dist = 100;

        foreach (Transform obj in TargetScript.AirTargets)
        {
            float checkDist = Vector3.Distance(transform.position, obj.position);
            if (checkDist < dist)
            {
                dist = checkDist;
                if (tar != obj)
                {
                    tar = obj;
                }
            }
        }

        return tar;
    }

    void FireRocket(Transform target)
    {
        Transform newRocket = Instantiate(Rocket, transform.position, transform.rotation);
        //newRocket.Translate(newRocket.forward * 1.5f);
        newRocket.GetComponent<HomingMissile>().target = target;
    }
}
