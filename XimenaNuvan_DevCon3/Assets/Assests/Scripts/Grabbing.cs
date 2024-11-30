using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grabbing : MonoBehaviour
{
    
    public float pickupRange = 2.0f;
    private GameObject heldObject;
    private Rigidbody heldObjectRb;
    private bool isHoldingWithLeftHand;

    public Animator anim;

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
            if (anim == null)
            {
                Debug.LogError("Animator component not found on the object!");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // Use E for picking up
        {
            anim.SetBool("isRightUp", true);

            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }
        else
        {
            anim.SetBool("isRightUp", false);
        }

        if (Input.GetKeyDown(KeyCode.R)) // Use E for picking up
        {
            anim.SetBool("isLeftUp", true);

            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }
        else
        {
            anim.SetBool("isLeftUp", false);
        }
    }

    void TryPickupObject()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.attachedRigidbody != null && collider.CompareTag("Item"))
            {
                heldObject = collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();


                AttachObjectToHand(transform);
                break;
            }
        }
    }

    void AttachObjectToHand(Transform handTransform)
    {
        // Disable physics and attach to the hand
        heldObjectRb.isKinematic = true;
        heldObject.transform.SetParent(handTransform);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.localRotation = Quaternion.identity;
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            // Detach and re-enable physics
            heldObject.transform.SetParent(null);
            heldObjectRb.isKinematic = false;

            // Add a small throw force
            heldObjectRb.AddForce(transform.forward * 2.0f, ForceMode.Impulse);

            heldObject = null;
            heldObjectRb = null;
        }
    }
}

    



