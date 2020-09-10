using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // For movement.
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private bool isMoving;
    private Vector2 moveVelocity = Vector2.zero;
    private Vector2 moveInput = Vector2.zero;

    // For jumping.
    [Header("Jumping")]
    [SerializeField] private Transform feetPosition;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpForce;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask ground;
    public bool isJumping { get; private set; }
    private bool isGrounded;
    private float jumpTimeCounter;
    private bool canMove = true;

    [Header("Climbing Ladders")]
    [SerializeField] private float checkDistance;
    [SerializeField] private LayerMask ladder;
    public bool isClimbing { get; private set; }
    private float originalGravityScale;

    private Rigidbody2D rb;
    private GameManager game;
    private Animator anim;
    private SpriteRenderer sprite;
    private RPGTalkController talk;

    public static PlayerController instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        talk = RPGTalkController.instance;
        talk.rpgtalk.OnNewTalk += DisableControls;
        talk.rpgtalk.OnEndTalk += EnableControls;
        originalGravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (!canMove) return;

        // Get axis input for movement.
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity.x = moveInput.x * moveSpeed;
        isMoving = moveInput != Vector2.zero;

        // Check for ladder input.
        // Find if the player is interacting with a ladder.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, checkDistance, ladder);
        if (hit.collider != null && moveInput.y > 0)
        {
            moveVelocity.y = moveInput.y * moveSpeed;
            isClimbing = true;
        }
        else
        {
            moveVelocity.y = 0;
            isClimbing = false;
        }

        // Check for jump input and apply the force.
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, ground);
        if (isGrounded && Input.GetKeyDown(KeyCode.P))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Debug.Log("Jump!");
            //rb.velocity = Vector3.up * jumpForce;
            moveVelocity.y = Vector3.up.y * jumpForce;
        }
        if (Input.GetKey(KeyCode.P) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                //rb.velocity = Vector3.up * jumpForce;
                moveVelocity.y = Vector3.up.y * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            isJumping = false;
        }
        if (!isJumping && !isClimbing)
        {
            moveVelocity.y = 0;
        }

        // Apply animations.
        if (moveInput.x > 0) sprite.flipX = false;
        if (moveInput.x < 0) sprite.flipX = true;
    }

    private void FixedUpdate()
    {
        // Apply movement.
        if (!canMove) rb.velocity = Vector2.zero;

        if (isClimbing)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = originalGravityScale;
        }
        rb.velocity = moveVelocity;
        //Debug.Log(rb.velocity);
    }


    private void DisableControls()
    {
        canMove = false;
    }

    private void EnableControls()
    {
        canMove = true;
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }

    public Vector2 GetMoveVelocity()
    {
        return moveVelocity;
    }

    private void OnDrawGizmos()
    {
        if (feetPosition == null) return;
        Vector3 pos = new Vector3(feetPosition.position.x, feetPosition.position.y, 0);
        Gizmos.DrawWireSphere(pos, checkRadius);
    }
}