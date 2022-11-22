using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float jumpSpeed = 1.0f;
    bool grounded = false;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            animator.SetTrigger("Jump");
        }
        if(rb.velocity.y < -0.1f && !grounded)
        {
            animator.SetTrigger("Fall");
        }
        animator.SetFloat("xInput", moveX);
        animator.SetBool("grounded", grounded);
        if(moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(moveX > 0)
        {
            spriteRenderer.flipX = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            rb.AddForce(new Vector2(0, 100 * 7));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
