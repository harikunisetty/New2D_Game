using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   /* [SerializeField] float Speed = 500f;
    [SerializeField] float jumpForce = 750f;
    private float xInput;*/

    [Header("Movement")]
    [SerializeField] float speed = 500f;
    [SerializeField] float maxVelocity = 2f, yInput;
    [SerializeField] float runSpeed = 2f;
    private bool facingRight = true;
    private float xInput;

    [Header("Jump")]
    [SerializeField] float jumpForce = 750f;
    [SerializeField] int currentJump, maxJump = 2;


    [Header("Ground")]
    [SerializeField] float range = 1f;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask layerMask;
    private RaycastHit2D leftHit, rightHIt;

    [Header("Components")]
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] Animator anim;
    void Start()
    {
        isGrounded = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float forceX = 0f, forceY = 0f;
        float velocity = Mathf.Abs(rigidbody2D.velocity.x);

        xInput = Input.GetAxis("Horizontal");
        //yInput = Input.GetAxis("Vertical");

        rigidbody2D.AddForce(new Vector2(forceX, 0f));

        if (xInput > 0)
        {
            // Run
            if (Input.GetKey(KeyCode.RightArrow))
            {
                maxVelocity = 7f;

                if (velocity < maxVelocity)
                    forceX = (speed * runSpeed) * Time.fixedDeltaTime;
            }
            else
            {
                // Walk
                maxVelocity = 5f;

                if (velocity < maxVelocity)
                    forceX = speed * Time.fixedDeltaTime;
            }
        }
        else if (xInput < 0)
        {
            // Run
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                maxVelocity = 3f;

                if (velocity < maxVelocity)
                    forceX = -(speed * runSpeed) * Time.fixedDeltaTime;
            }
            else
            {
                // Walk
                maxVelocity = 2f;

                if (velocity < maxVelocity)
                    forceX = -speed * Time.fixedDeltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
           

            if (isGrounded)
                forceY = jumpForce;

            if (Input.GetKeyDown(KeyCode.Space))
                anim.SetBool("Jump", true);
            else
                anim.SetBool("Jump", false);

        }

        rigidbody2D.AddForce(new Vector2(forceX, forceY * Time.fixedDeltaTime), ForceMode2D.Impulse);
        anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));

        if (Input.GetKeyDown(KeyCode.S))
            anim.SetBool("Run", true);
        else
            anim.SetBool("Run", false);

       
    }
    /*xInput = Input.GetAxis("Horizontal");
    rigidbody2D.velocity = new Vector2(xInput * speed, rigidbody2D.velocity.y);

    if (Input.GetButtonDown("Jump"))
    {
        rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, jumpForce),ForceMode2D.Impulse);
    }
}
*/

}

