using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public CreateTargets TargetScript;
    public bool ground;
    //public Transform target;
    public float speed = 2;
    bool canFire = true;

    private void Start()
    {
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 100.0f))
        {
            if (canFire)
            {
                canFire = false;
                if (ground) TargetScript.Targets.Remove(hit.collider.gameObject.transform);
                else TargetScript.AirTargets.Remove(hit.collider.gameObject.transform);
                Destroy(hit.collider.gameObject);
                print("kill");
            }
        }

        else

        {
            print("no hit");
        }

        //debug only
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

void Update()
    {
        if (ground) MoveTurret();
        else MoveAirTurret();
    }

    void MoveTurret()
    {
        if (GetNextTarget() != null)
        {
            Vector3 targetDir;

            if (ground) targetDir = GetNextTarget().position - transform.position;
            else targetDir = GetNextAirTarget().position - transform.position;

            //Vector3 targetDir = target.position - transform.position;

            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);

            if (ground) transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }
    }

    void MoveAirTurret()
    {
        if (GetNextAirTarget() != null)
        {
            Vector3 targetDir;

            if (ground) targetDir = GetNextTarget().position - transform.position;
            else targetDir = GetNextAirTarget().position - transform.position;

            //Vector3 targetDir = target.position - transform.position;

            float step = speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);

            if (ground) transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }
    }

    Transform GetNextTarget()
    {
        Transform tar = null;
        float dist = 100;

        foreach(Transform obj in TargetScript.Targets)
        {
            float checkDist = Vector3.Distance(transform.position, obj.position);
            if (checkDist < dist)
            {
                dist = checkDist;
                if (tar != obj)
                {
                    canFire = true;
                    tar = obj;
                }
            }
        }

        return tar;
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
                    canFire = true;
                    tar = obj;
                }
            }
        }

        return tar;
    }
}
