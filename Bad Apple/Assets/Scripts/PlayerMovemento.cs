using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovemento : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    //health stuff
    public float playerHealth = 3f;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

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

        if (playerHealth > numOfHearts)
        {
            playerHealth = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < playerHealth)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                    
                    Destroy(collision.gameObject);
                    playerHealth++;
                    numOfHearts++;

                }
            }
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
