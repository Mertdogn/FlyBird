using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int upForce = 200;
    private bool isDead = false;
    private Animator anim;
    public GameController controller;
    public TextMeshProUGUI scoreText;
    private int score;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scoreText.text = "0";
        score = 0;

    }

    private void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Player") && collision.gameObject.CompareTag("Ground") || Variables.isLive == 1)
        {
            isDead = true;
            anim.SetTrigger("Die");
            controller.birdDied();
            rb2d.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.tag);
        Debug.Log(collision.gameObject.tag);

        if (gameObject.CompareTag("Player") && collision.gameObject.CompareTag("ScoreArea"))
        {
            /*
             float yPosition = gameObject.transform.position.y;
             float truncatedValue = Mathf.Round(yPosition * 10) / 10f;
             score += truncatedValue; 
            */
            score++;
            scoreText.text = ("Total Score ") + score.ToString();

        }
    }
}
