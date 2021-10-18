using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    [SerializeField] float speed = 500f;
    [SerializeField] float runSpeed = 2f;
    private bool facingRight = true;
    private float xInput;
    public bool isGrounded;

    [Header("PlayerHealth")]
    [SerializeField] HealthManagaer PlayerHealth;
    [SerializeField] float Hitvalue = 10f;

    void Start()
    {
        isGrounded = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerHealth = GetComponent<HealthManagaer>();
    }
    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && rb2d.velocity.y == 0)
            rb2d.AddForce(Vector2.up * 900f);

        if (Mathf.Abs(xInput) > 0 && rb2d.velocity.y == 0)
            anim.SetBool("isWalking",true);
        else
            anim.SetBool("isWalking",false);

        if (rb2d.velocity.y == 0)   
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        if (rb2d.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
            
        }
        if (rb2d.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        rb2d.velocity = new Vector2(xInput, rb2d.velocity.y);
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Hit");
        }
       
        if (xInput > 0 && !facingRight) 
        {
            FilpCharacter();
        }
        else if (xInput < 0 && facingRight)
        {
            FilpCharacter();
        }
    }

    public void FilpCharacter()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
   
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Coin"))
        {
           Destroy(collider2D.gameObject);
            GameManager.Instance.UpdateCoins();
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealth.PlayerDamage(40f);
        }
    }
}
