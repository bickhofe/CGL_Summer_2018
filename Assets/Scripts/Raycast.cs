using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public ReticleObject Reticle;
    InteractiveObject currentObject;

    //received message from reticle
    public void ObjectSelected()
    {
        print("message received!");
        currentObject.select();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        

        if (Physics.Raycast(transform.position, fwd, out hit, 100.0f))
        {
            print("Hit at: " + hit.collider.name); //hit.distance

            if (hit.collider.GetComponent<InteractiveObject>() != null)
            {
                currentObject = hit.collider.GetComponent<InteractiveObject>();
                currentObject.onOver();
                Reticle.isActive = true;
            }
            
        }
        else
        {
            print("no hit");
            if (Reticle.isActive) Reticle.isActive = false;

            if (currentObject != null)
            {
                currentObject.onOut();
                currentObject = null;
            }
        }
        
        //debug only
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}