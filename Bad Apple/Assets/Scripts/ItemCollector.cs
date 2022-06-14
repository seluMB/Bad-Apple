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
            Destroy(collision.gameObject);
            peach.enabled = true;
            isImgOn = true;
        }

        if (collision.gameObject.CompareTag("Lemon"))
        {
            Destroy(collision.gameObject);
            lemon.enabled = true;
            isImgOn = true;
        }

        if (collision.gameObject.CompareTag("Strawberry"))
        {
            Destroy(collision.gameObject);
            strawberry.enabled = true;
            isImgOn = true;
        }

        if (collision.gameObject.CompareTag("Pear"))
        {
            Destroy(collision.gameObject);
            pear.enabled = true;
            isImgOn = true;
        }
    }
}
