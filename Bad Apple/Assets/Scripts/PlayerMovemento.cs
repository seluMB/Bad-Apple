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

    // Pause check
    public static bool GameIsPaused = false;

    //health stuff
    public float playerHealth = 4f;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
   

    // Get Input
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        // walk sound manager
        if (Input.GetKeyDown(KeyCode.A))
        {

            FindObjectOfType<AudioManager>().Play("Walking");
        }

        if(Input.GetKeyDown(KeyCode.D))
        {

            FindObjectOfType<AudioManager>().Play("Walking");
        }

      

        


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

        //Pause Menu
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<GameManager>().Pause();
        }*/

        //Heart UI
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

    //Health Colelctible
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            FindObjectOfType<AudioManager>().Play("PowerUp");
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


    //Health Manager & Restart Bullet
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
            Debug.Log("Hit!");
            Destroy(col.gameObject);
            playerHealth = playerHealth - 1f;
            
            if (playerHealth <= 0)
            {
                
                FindObjectOfType<LoseMenu>().Lost();
            }       
        }

        // HealthManager & Restart Touch
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Touch");
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
            playerHealth = playerHealth - 1f;

            if (playerHealth <= 0)
            {
                FindObjectOfType<LoseMenu>().Lost();
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
