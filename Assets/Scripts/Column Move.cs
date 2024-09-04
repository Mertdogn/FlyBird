using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-1.5f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb2d.velocity = Vector2.zero;
            Variables.isLive = 1;
            Time.timeScale = 0;
        }
    }
}
