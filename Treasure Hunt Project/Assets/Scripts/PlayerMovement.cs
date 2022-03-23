using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float runSpeed = 5.0f;
    public float jumpSpeed = 10.0f;
    public float gravityScale = 2.5f;

    //PLAYER COMPONENTS
    public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;

    private bool isGrounded = false;

    [SerializeField]
    float moveX;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravityScale;
    }

    private void FixedUpdate() //imput for physics and stuff
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        /*
        if (Dialogue.GetInstance().narrationIsPlaying)
        {
            return;
        }*/

        UpdateIsGrounded();
        HandleHorizontalMovement();
        HandleJumping();
        
    }

    private void UpdateIsGrounded()
    {
        Bounds colliderBounds = coll.bounds;
        float colliderRadius = coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckpos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckpos, colliderRadius);

        this.isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != coll)
                {
                    this.isGrounded = true;
                    break;
                }
            }
        }
    }

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        rb.velocity = new Vector2(moveDirection.x * runSpeed, rb.velocity.y);
    }

    private void HandleJumping()
    {
        //Debug.Log(isGrounded);
        bool jumpPressed = InputManager.GetInstance().GetJumpPressed();
        if (isGrounded && jumpPressed)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    //CHECKS FOR ISGROUNDED
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

    }

    void PlayerControls()
    {
        moveX = Input.GetAxis("Horizontal");
    }

    void Update() //SPRITE RENDERING
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            moveX = 0;
        }
        else
        {
            moveX = Input.GetAxis("Horizontal");
        }
     
        PlayerControls();
        animator.SetFloat("Speed", Mathf.Abs(moveX));
        
        if (moveX > 0 ) //moving to the right
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
