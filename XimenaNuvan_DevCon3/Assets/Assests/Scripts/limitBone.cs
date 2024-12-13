using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class limitBone : MonoBehaviour

{
    public Rigidbody boneRigidbody; // Rigidbody of the bone
    private Vector3 initialPosition; // Initial local position
    private Quaternion initialRotation; // Initial local rotation

    void Start()
    {
        // Store the initial local position and rotation relative to the parent
        initialPosition = boneRigidbody.transform.localPosition;
        initialRotation = boneRigidbody.transform.localRotation;
    }

    void LateUpdate()
    {
        // Calculate target world position and rotation
        Vector3 targetPosition = boneRigidbody.transform.parent.TransformPoint(initialPosition);
        Quaternion targetRotation = boneRigidbody.transform.parent.rotation * initialRotation;

        // Use MovePosition and MoveRotation for physics-safe adjustments
        boneRigidbody.MovePosition(Vector3.Lerp(boneRigidbody.position, targetPosition, 0.1f));
        boneRigidbody.MoveRotation(Quaternion.Slerp(boneRigidbody.rotation, targetRotation, 0.1f));
    }
}




