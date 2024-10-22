using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public Animator A_OpenGarage;

    public bool isGrabbing = false;
    public Transform rightHand;
    public GameObject grabbedObject;
    public float grabDistance = 3f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenGarage();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isGrabbing)
            {
                ReleaseObject();
                GrabObject();
            }
            else
            {
                GrabObject();
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ReleaseObject();
        }
    }

    public void OpenGarage()
    {
        A_OpenGarage.GetComponent<Animator>();
        A_OpenGarage.enabled = true;
    }

    private void GrabObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance))
        {
            if (hit.collider.CompareTag("Item"))
            {
                grabbedObject = hit.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                grabbedObject.transform.SetParent(Camera.main.transform);
                grabbedObject.transform.position = rightHand.position;

                isGrabbing = true;
            }
        }
    }

    private void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.transform.parent = null;
            grabbedObject = null;
            
            isGrabbing = false;
        }
    }
}
