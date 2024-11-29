using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;        // Player's transform to follow
    public Vector3 offset;          // Camera offset from the player
    public float followSpeed = 10f; // Smoothness of the camera movement
    public float rotationSpeed = 5f; // Speed of camera rotation
    public float minPitch = -35f;   // Minimum vertical rotation (to prevent flipping)
    public float maxPitch = 60f;    // Maximum vertical rotation

    private float yaw = 0f;         // Horizontal rotation (yaw)
    private float pitch = 0f;       // Vertical rotation (pitch)

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform not assigned!");
            enabled = false;
            return;
        }

        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor for camera control
    }

    void LateUpdate()
    {
        HandleRotation();  // Rotate the camera based on input
        FollowPlayer();    // Move the camera to follow the player
    }

    void HandleRotation()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Update yaw and pitch
        yaw += mouseX;
        pitch -= mouseY;

        // Clamp the pitch to prevent flipping
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Apply rotation to the camera
        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }

    void FollowPlayer()
    {
        // Calculate the direction the camera is facing
        Vector3 forward = transform.forward;
        forward.y = 0; // Keep the movement on a flat plane

        // Position the camera relative to the player's movement direction
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}





