using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector2 movement;
    private CapsuleCollider2D capsuleCollider;
    public LayerMask groundLayer;
    [SerializeField] private float JumpVelocity;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform groundCheck;
    private bool isMoving = false;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        movement = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //WASD or left and right
        Moving();
        //Space
        Jumping();
    }

    private void Moving()
    {
        float x = Input.GetAxis("Horizontal");
        if (x != 0)
        {
            isMoving = true;
            movement.x = x;
            //in this case, walk animation is only played, when player isGrounded
            if (isGrounded())
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }
        else
        {
            animator.SetBool("Walk", false);
            isMoving = false;
            movement.x = 0;
        }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown("space") && isGrounded())
        {
            isJumping = true;

        }
    } 

    private void FixedUpdate()
    {
        // only when isMoving is true, player can walk by changing the velocity
        if (isMoving)
        {
            playerRigidBody.velocity = new Vector2(movement.x * movementSpeed, playerRigidBody.velocity.y);
        }
        // only when isJumping is true, player can jump by changing the velocity
        if (isJumping)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, JumpVelocity);
            isJumping = false;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .1f, groundLayer);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit!");
            Destroy(col.gameObject);

        }
        
    }
}
