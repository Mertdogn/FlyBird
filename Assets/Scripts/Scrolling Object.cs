using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameController controller;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-1.5f, 0);
    }

    public void FixedUpdate()
    {
        if (controller.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;

        }
        if (transform.position.x < -5.7f)
        {
            transform.position = new Vector2(5.8f, -4.6f);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
        }
    }
}
