using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // For movement.
    [SerializeField] private float moveSpeed;
    private bool isMoving;
    private float moveVelocity;

    // For jumping.
    [SerializeField] private Transform feetPosition;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpForce;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask ground;
    private bool isJumping;
    private bool isGrounded;
    private float jumpTimeCounter;

    private Rigidbody2D rb;
    private GameManager game;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get axis input for movement.
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        isMoving = moveInput != Vector3.zero;
        moveVelocity = moveInput.x * moveSpeed;

        // Check for jump input.
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, ground);
        if (isGrounded && Input.GetKeyDown(KeyCode.P))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Debug.Log("Jump!");
            rb.velocity = Vector3.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.P) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
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
    }

    private void FixedUpdate()
    {
        // Apply movement.
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        if (feetPosition == null) return;
        Vector3 pos = new Vector3(feetPosition.position.x, feetPosition.position.y, 0);
        Gizmos.DrawWireSphere(pos, checkRadius);
    }
}