using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabRight : MonoBehaviour
{
	
    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;

    private GameObject objectInHand;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
        Debug.Log(collidingObject.tag);
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        Debug.Log("OnTriggerEnter");
		if (other.tag == "handle")
        {
            if (Controller.GetHairTriggerDown())
            {
                SimpleCarController.Axis = -1;
            }
        }

    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
        Debug.Log("OnTriggerStay");
		if (other.tag == "handle")
        {
            if (Controller.GetHairTriggerDown())
            {
                SimpleCarController.Axis = -1;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
		
        collidingObject = null;
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }

        objectInHand = null;
    }

    void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
                //Debug.Log("Grab");
            }
        }
        SimpleCarController.Horizontal = Controller.GetAxis().x;

        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
            SimpleCarController.Axis = 0;
        }
    }
}