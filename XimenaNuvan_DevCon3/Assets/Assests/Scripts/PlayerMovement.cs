using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator Anim;
    public float speed;
    public float strafeSpeed;
    public float jumpForce;

    public Rigidbody hips1;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        hips1 = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       
    }

    public void movement()
    {

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                hips1.AddForce(-hips1.transform.forward * speed);

                //if (Input.GetKey(KeyCode.LeftShift))
                // {
                //    Anim.SetBool("IsRun", true);
                //     hips1.AddForce(-hips1.transform.forward * speed * 1.5f);
                // }
            }

            else
            {
                Anim.SetBool("IsWalk", false);

            }

            if (Input.GetKey(KeyCode.A))
            {
                hips1.AddForce(hips1.transform.right * strafeSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                hips1.AddForce(hips1.transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                hips1.AddForce(-hips1.transform.right * strafeSpeed);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Anim.SetBool("Other", true);

                hips1.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
            else
            {
                Anim.SetBool("Other", false);
            }

        }
    }


}
