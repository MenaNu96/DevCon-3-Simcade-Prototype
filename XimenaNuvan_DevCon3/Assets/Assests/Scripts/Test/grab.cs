using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public Animator animator; // Reference to the Animator
    public Rigidbody rb; // Rigidbody of the player or hand
    public int mouseButtonIndex; // 0 = Left Mouse Button, 1 = Right Mouse Button
    private GameObject grabbedObject; // Object currently being grabbed
    private bool alreadyGrabbing = false;

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
        // Trigger animation when mouse button is pressed
        if (Input.GetMouseButtonDown(mouseButtonIndex))
        {
            animator.SetBool(mouseButtonIndex == 0 ? "isLeftUp" : "isRightUp", true);
            alreadyGrabbing = true;

            // Attempt to grab object if available
            TryGrabObject();
        }
        else if (Input.GetMouseButtonUp(mouseButtonIndex))
        {
            animator.SetBool(mouseButtonIndex == 0 ? "isLeftUp" : "isRightUp", false);
            alreadyGrabbing = false;

            // Release object if grabbing
            ReleaseObject();
        }
    }

    private void TryGrabObject()
    {

        if (grabbedObject != null)
        {
            // Disable Rigidbody physics on the grabbed object
            Rigidbody grabbedRb = grabbedObject.GetComponent<Rigidbody>();
            if (grabbedRb != null)
            {
                grabbedRb.isKinematic = true;
            }
            //if (grabbedObject != null)
            //{
            // Rigidbody grabbedRb = grabbedObject.GetComponent<Rigidbody>();
            //if (grabbedRb == null)
            // {
            // Debug.LogError("Grabbed object needs a Rigidbody!");
            //return;
            // }

            // Parent the grabbed object to the hand
            grabbedObject.transform.SetParent(this.transform);

            Debug.Log("Object grabbed and parented!");

            if (grabbedRb != rb)
                    {
                        FixedJoint joint = grabbedObject.AddComponent<FixedJoint>();
                        joint.connectedBody = rb;
                        joint.breakForce = 10000f; // Prevent joint from breaking easily
                        joint.breakTorque = 10000f;

                        // Adjust Rigidbody properties for stability
                        rb.mass = Mathf.Max(rb.mass, grabbedRb.mass); // Ensure arm's mass is sufficient
                        rb.drag = 1f;
                        rb.angularDrag = 5f;

                        Debug.Log("Object grabbed!");
                    }
                    else
                    {
                        Debug.LogWarning("Cannot attach joint to the same Rigidbody!");
                    }
                
            //}
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
                            grabbedRb.isKinematic = false;
                        }

                        // Unparent the grabbed object
                        grabbedObject.transform.SetParent(null);
                        grabbedObject = null;

                        Debug.Log("Object released!");
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
                    if (!alreadyGrabbing && other.gameObject == grabbedObject)
                    {
                        grabbedObject = null;
                    }
                }
            }
        
