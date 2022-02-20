using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    float jumpStrength = 5.0f;

    [SerializeField]
    float movementSpeed = 5.0f;
    float moveX;

    bool canJump = false;
    bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void PlayerControls()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
    }

    void Jump()
    {
        if (!isGrounded)
        {
            return; //just stop and dont cgeck anything else underneath it
        }

        isGrounded = false;
        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse); //shorthand for Vector2(0,1)
       // Debug.Log("Jump!", gameObject); //lights up thing that printed the message
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
       // Debug.Log("Hit something", collision.gameObject);

    }

    private void FixedUpdate() //imput for physics and stuff
    {
        rb.velocity = new Vector2(moveX * movementSpeed, rb.velocity.y);
        if (canJump == true)
        {
            canJump = false;
            Jump();
        }
    }
   
    void Start()
    {
        
    }


    void Update() //displaying physics and stuff
    {
        PlayerControls();
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        
        if (moveX > 0) //moving to the right
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = true;
            }
        }

        if (moveX < 0)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}
