using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public Animator animator; // Reference to the Animator
    public Rigidbody rb; // Rigidbody of the player or hand
    public int mouseButtonIndex; // 0 = Left Mouse Button, 1 = Right Mouse Button
    private GameObject grabbedObject; // Object currently being grabbed
    private bool isGrabbing = false; // Toggle for grab state

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if (animator == null)
        {
            Debug.LogError("Animator not assigned!");
        }
    }

    void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(mouseButtonIndex))
        {
            if (isGrabbing)
            {
                // Release the object
                animator.SetBool(mouseButtonIndex == 0 ? "isLeftUp" : "isRightUp", true);
                ReleaseObject();
            }
            else
            {
                // Grab the object
                TryGrabObject();
            }
            animator.SetBool(mouseButtonIndex == 0 ? "isLeftUp" : "isRightUp", false);
            // Toggle grabbing state
            isGrabbing = !isGrabbing;
        }
    }

    private void TryGrabObject()
    {
        if (grabbedObject != null)
        {
            Rigidbody grabbedRb = grabbedObject.GetComponent<Rigidbody>();
            if (grabbedRb == null)
            {
                Debug.LogWarning("Grabbed object does not have a Rigidbody!");
                return;
            }

            // Parent the grabbed object to the hand
            grabbedObject.transform.SetParent(this.transform);

            // Ensure Rigidbody is NOT kinematic so it responds to forces
            grabbedRb.isKinematic = false;

            // Add a FixedJoint to the grabbed object
            FixedJoint joint = grabbedObject.GetComponent<FixedJoint>();
            if (joint == null) // Ensure no duplicate joints
            {
                joint = grabbedObject.AddComponent<FixedJoint>();
            }
            joint.connectedBody = rb;
            joint.breakForce = 10000f;
            joint.breakTorque = 10000f;

            Debug.Log("Object grabbed and can move!");
        }
        else
        {
            Debug.LogWarning("No object available to grab!");
        }
    }


    private void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            // Re-enable Rigidbody physics
            Rigidbody grabbedRb = grabbedObject.GetComponent<Rigidbody>();
            if (grabbedRb != null)
            {
               // grabbedRb.isKinematic = false;
            }

            // Remove FixedJoint
            FixedJoint joint = grabbedObject.GetComponent<FixedJoint>();
            if (joint != null)
            {
                Destroy(joint);
            }

            // Unparent the grabbed object
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;

            Debug.Log("Object released!");
        }
        else
        {
            Debug.LogWarning("No object to release!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            grabbedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isGrabbing && other.gameObject == grabbedObject)
        {
            grabbedObject = null;
        }
    }

}

