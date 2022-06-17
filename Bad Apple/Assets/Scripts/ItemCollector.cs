using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public bool isImgOn;
    public Image peach;
    public Image lemon;
    public Image strawberry;
    public Image pear;

    void Start()
    {
        peach.enabled = false;
        lemon.enabled = false;
        strawberry.enabled = false;
        pear.enabled = false;
        isImgOn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Peach"))
        {
            FindObjectOfType<AudioManager>().Play("Fruit_1");
            Destroy(collision.gameObject);
            peach.enabled = true;
            isImgOn = true;
        }

        if (collision.gameObject.CompareTag("Lemon"))
        {
            FindObjectOfType<AudioManager>().Play("Fruit_2");
            Destroy(collision.gameObject);
            lemon.enabled = true;
            isImgOn = true;
        }

        if (collision.gameObject.CompareTag("Strawberry"))
        {
            FindObjectOfType<AudioManager>().Play("Fruit_3");
            Destroy(collision.gameObject);
            strawberry.enabled = true;
            isImgOn = true;
            //TriggersWinning
            FindObjectOfType<WinMenu>().Win();
        }

        if (collision.gameObject.CompareTag("Pear"))
        {
            FindObjectOfType<AudioManager>().Play("Fruit_4");
            Destroy(collision.gameObject);
            pear.enabled = true;
            isImgOn = true;
        }
    }
}
