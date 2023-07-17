using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed;
    Rigidbody2D rb;
    Animator anim;

    public bool isStatic;
    public bool isWalker;

    public bool walksRight;
    public bool isPatrol;
    public bool shouldWait;
    public float timeToWait;
    public bool isWaiting;


    public Transform wallCheck, pitCheck, groundCheck;
    bool wallDetected, pitDetected, isGrounded;
    public float detectRadius;
    public LayerMask whatIsGround;

    public Transform pointA, pointB;
    bool goToA, goToB;

    void Start()
    {
        goToA = true;
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, detectRadius, whatIsGround);

        if (pitDetected || wallDetected && isGrounded)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (isStatic)
        {
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }

        if (isWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);
            if (!walksRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            } else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }

        if (isPatrol)
        {
            
            if (goToA)
            {
                if(!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                }
                

            if(Vector2.Distance(transform.position, pointA.position) <0.2F)
                {
                    if(shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    Flip();
                    goToA = false;
                    goToB = true;
                }
            }

            if(goToB)
            {
                if(!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                }
                

                if (Vector2.Distance(transform.position, pointB.position) < 0.2F)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    Flip();
                    goToA = true;
                    goToB = false;
                }
            }
        }  
    }

    public IEnumerator Waiting()
    {
        anim.SetBool("Idle", true);
        isWaiting = true;
        Flip();
        yield return new WaitForSeconds(timeToWait);
        isWaiting = false;
        anim.SetBool("Idle", false);
        Flip();
    }
    public void Flip()
    {
        walksRight = !walksRight;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }
}