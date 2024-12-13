using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public Rigidbody mainRigidbody; // The primary Rigidbody (e.g., pelvis or torso)
    public Transform playerBody; // The player's body (for Y-axis rotation)
    public Transform cameraTransform; // The camera (for up-down tilt)
    public float movementSpeed = 5f; // Movement speed
    public float jumpForce = 5f; // Jump force
    public LayerMask groundLayer; // Ground layer for ground check
    public Transform groundCheck; // Position to check for ground contact
    public float groundCheckRadius = 0.2f; // Radius of the ground check sphere
    public Animator animator; // Reference to Animator
    public float mouseSensitivity = 100f; // Sensitivity for mouse rotation

    private bool isGrounded = false; // Whether the character is on the ground
    private float xRotation = 0f; // Camera's vertical rotation (to prevent over-rotation)

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        // Check if the ragdoll is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("Ground", isGrounded);
        // Handle movement
        Move();
        RotateWithMouse();
        // Handle jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void RotateWithMouse()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player body around the Y-axis (horizontal rotation)
        playerBody.Rotate(Vector3.up * mouseX);

        // Tilt the camera up and down (clamping to prevent over-rotation)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void Move()
    {
        // Get input for horizontal and vertical movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", z);


        Vector3 movement = playerBody.forward * z + playerBody.right * x;
        // Calculate movement direction
        //Vector3 movement = new Vector3(x, 0, y).normalized;

        // Apply force to the main rigidbody for movement
        if (movement.magnitude >= 0.1f)
        {
            mainRigidbody.AddForce(movement.normalized * movementSpeed, ForceMode.Force);
        }
    }

    private void Jump()
    {
        // Apply an upward force to the main rigidbody for jumping
        mainRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("Jumping");
    }

    private void OnDrawGizmos()
    {
        // Draw the ground check sphere in the editor for debugging
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}

