using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemento : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public float playerHealth = 3f;

    // Get Input
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit!");
            Destroy(col.gameObject);
            playerHealth = playerHealth - 1f;
            
            if (playerHealth <= 0)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Touch");
           
            playerHealth = playerHealth - 1f;

            if (playerHealth <= 0)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }

    }

    // Apply Input 
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
