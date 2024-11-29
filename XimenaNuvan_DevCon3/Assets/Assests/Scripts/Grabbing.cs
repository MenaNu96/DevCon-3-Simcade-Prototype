using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ObjectGrabber : MonoBehaviour
    {
        public Animator animator;
        private GameObject grabbedObject;
        private Rigidbody rb;
        public int isLeftOrRight; // 0 = Left Mouse Button, 1 = Right Mouse Button
        private bool alreadyGrabbing = false;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody component is missing on this GameObject.");
            }
        }

        void Update()
        {
        if (Input.GetMouseButtonDown(isLeftOrRight))
        {
            alreadyGrabbing = true;

            if (isLeftOrRight == 0)
            {
                animator.SetBool("isLeftUp", true);
                Debug.Log("Left hand animation triggered");
            }
            else if (isLeftOrRight == 1)
            {
                animator.SetBool("isRightUp", true);
                Debug.Log("Right hand animation triggered");
            }

            FixedJoint joint = grabbedObject.AddComponent<FixedJoint>();
            joint.connectedBody = rb;
            joint.breakForce = 9001;
        }
           else if (Input.GetMouseButtonUp(isLeftOrRight))
            {
                //alreadyGrabbing = false;

                    if (isLeftOrRight == 0)
                    {
                        animator.SetBool("isLeftUp", false);
                        Debug.Log("Left hand animation stopped");
                    }
                    else if (isLeftOrRight == 1)
                    {
                        animator.SetBool("isRightUp", false);
                        Debug.Log("Right hand animation stopped");
                    }
            

                if (grabbedObject != null)
                {
                    Destroy(grabbedObject.GetComponent<FixedJoint>());
                    grabbedObject = null;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Item"))
            {
                grabbedObject = other.gameObject;
            }
            else
            {
                Debug.Log("Object without 'Item' tag entered trigger: " + other.gameObject.name);
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



