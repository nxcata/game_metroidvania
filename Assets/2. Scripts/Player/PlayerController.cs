using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpHeight;
    float velX, VelY;
    Rigidbody2D rb;
    public Transform DetectGround;
    public bool isGrounded;
    public float DetectGroundRadius;
    public LayerMask whatIsGround;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(DetectGround.position, DetectGroundRadius, whatIsGround);
        
        if(isGrounded)
        {
            anim.SetBool("Jump", false);
        }else
        {
            anim.SetBool("Jump", true);
        }

        Flip();
        Attack();


    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    public void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true); 
        }else

        {
            anim.SetBool("Attack", false);
        }
    }

    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        VelY = rb.velocity.y;
        rb.velocity = new Vector2(velX * speed, VelY);

        if(rb.velocity.x != 0)
        {
            anim.SetBool("Run", true);
        }else
        {
            anim.SetBool("Run", false);
        }
    }

    public void Flip()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump()
    {
        if(Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
}
