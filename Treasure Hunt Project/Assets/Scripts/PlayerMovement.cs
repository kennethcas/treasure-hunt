using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToActivate2;
    AudioSource keyBleep;
    [Header("Movement Parameters")]
    public float runSpeed = 3.0f;
    public float jumpSpeed = 6.4f;
    public float gravityScale = 1.0f;

    //PLAYER COMPONENTS
    public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;

    private bool isGrounded = false;

    [SerializeField]
    float moveX;

    private bool ghostTrigger = false;
    private bool interactPressed = false;

    public bool interactedWithGhostNPC { get; private set; }

    private static PlayerMovement instance;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravityScale;

        
    }

    public static PlayerMovement GetInstance()
    {
        return instance;
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

    void Start()
    {
        keyBleep = GetComponent<AudioSource>();
        interactedWithGhostNPC = false;
        ghostTrigger = false;
    }

    //CHECKS FOR ISGROUNDED
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            keyBleep.Play(0);
            //Debug.Log("colliding with key");
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ghost")
        {
            ghostTrigger = true;
            /*
            if (InputManager.GetInstance().GetInteractPressed())
            {
                Debug.Log("Interact button pressed");
                interactedWithGhostNPC = true;
            }*/
            
        }
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

        Debug.Log(interactedWithGhostNPC);

        if (InputManager.GetInstance().GetInteractPressed())
        {
            Debug.Log("Interact button pressed");
            interactPressed = true;
            if (ghostTrigger == true)
            {
                interactedWithGhostNPC = true;
            }
            //interactedWithGhostNPC = true;
        }
        if (!InputManager.GetInstance().GetInteractPressed())
        {
            Debug.Log("Interact button NOT pressed");
            interactPressed = false;
        }

        if (interactedWithGhostNPC)
        {
            objectToActivate.SetActive(true);
            objectToActivate2.SetActive(true);
        }
    }
}
