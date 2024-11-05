using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    [SerializeField] float jumpSpeed = 0f;
    private float direction = 0f;
    private Rigidbody2D player;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;

    private Vector3 respawnPoint;
    [SerializeField] GameObject fallDetector;

    [SerializeField] Text scoreText;

    [SerializeField] HealthBar healthBar;

    AudioSource jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        scoreText.text = Scoring.totalScore.ToString();
        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(0.31941f, 0.31941f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-0.31941f, 0.31941f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            jumpSound.Play();
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Crystal")
        {
            Scoring.totalScore += 1;
            scoreText.text = Scoring.totalScore.ToString();
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Spike")
        {
            healthBar.Damage(0.002f);
        }
    }
}


//https://www.youtube.com/watch?v=RYw8lAI-_Y0&list=PLGmYIROty-5YPWeXeVnQvR9KbMIrL5cM-&index=3 by Daniel Wood
