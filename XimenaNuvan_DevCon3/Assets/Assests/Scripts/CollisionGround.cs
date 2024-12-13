using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGround : MonoBehaviour
{
    public MovePlayer PlayerMove;
    public LayerMask whatIsGround;
    public float maxSlopeAngle = 35f;
    private Vector3 normalVector = Vector3.up;
    public Animator animator;

    private void Start()
    {
        PlayerMove = GameObject.FindObjectOfType<MovePlayer>().GetComponent<MovePlayer>();
        //PlayerMove = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }

    private bool IsFloor(Vector3 v)
    {
        float angle = Vector3.Angle(Vector3.up, v);
        return angle < maxSlopeAngle;
    }

    private bool cancellingGrounded;
    private void OnCollisionEnter(Collision other)
   {
        animator.SetBool("Other", false);
        //PlayerMove.grounded = true;
       // PlayerMove.grounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, whatIsGround);

        //Make sure we are only checking for walkable layers
        int layer = other.gameObject.layer;
   if (whatIsGround != (whatIsGround | (1 << layer))) return;

    //Iterate through every collision in a physics update
    for (int i = 0; i < other.contactCount; i++)
    {
      Vector3 normal = other.contacts[i].normal;
    //FLOOR
    if (IsFloor(normal))
    {
     PlayerMove.grounded = true;
     cancellingGrounded = false;
    // normalVector = normal;
    // CancelInvoke(nameof(StopGrounded));
     }
    }

    //Invoke ground/wall cancel, since we can't check normals with CollisionExit
    //float delay = 3f;
     if (!cancellingGrounded)
     {
      cancellingGrounded = true;
       // Invoke(nameof(StopGrounded), Time.deltaTime * delay);
     }
     }
   // private void OnCollisionEnter(Collision collision)
   // {
  // PlayerMove.grounded = true;
   // }
}


