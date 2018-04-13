using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{

    public OVRInput.Controller controller = OVRInput.Controller.LTouch;

    // Update is called once per frame
    void Update()
    {
        OVRInput.RecenterController();
        transform.localPosition = OVRInput.GetLocalControllerPosition(controller);
        transform.rotation = OVRInput.GetLocalControllerRotation(controller);

        //float trigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        //transform.localScale = Vector3.one * (0.05f + 0.1f * trigger);

        float grip = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
        GetComponent<Renderer>().material.color = Color.red * grip + (1 - grip) * Color.blue;
        foreach (var button in Enum.GetValues(typeof(OVRInput.Button)))
        {
            if (OVRInput.GetUp((OVRInput.Button)button, controller))
            {
                if (this.transform.childCount > 0)
                {
                    for(int i = 0; i < transform.childCount; i++)
                    {
                        transform.GetChild(i).parent = null;
                    }
                }
            }
        }

        //Vector2 stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        //float xMove = stick.x * Time.deltaTime;
        //float yMove = stick.y * Time.deltaTime;

        //this.transform.parent.Translate(Vector3.forward * yMove);
        //this.transform.parent.Rotate(Vector3.up * 20 * xMove);

    }
    void OnTriggerStay(Collider other)
    {
        foreach (var button in Enum.GetValues(typeof(OVRInput.Button)))
        {
            if (OVRInput.GetDown((OVRInput.Button)button, controller) && other.gameObject.tag != "Player")
            {
                other.gameObject.transform.parent = this.gameObject.transform;
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                //other.gameObject.transform.rotation = this.gameObject.transform.rotation;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
