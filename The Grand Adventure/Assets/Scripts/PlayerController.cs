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

    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip crystal;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        scoreText.text = Scoring.totalScore.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if the palyer is on the ground
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //direction is set to the horizontal inputs (A and D)
        direction = Input.GetAxis("Horizontal");
        //if direction is greater than 0 then the player will move with a velocity and will turn in the direction 
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
        //if the jump button (Space) is pressed and the player in on the ground then the player will jump with set jump speed and the jump sound will play
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            GetComponent<AudioSource>().PlayOneShot(jumpSound);
        }
        //Float and Bool for the animations of walking and jumping
        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
        //the fall detector transfroms the position of the player 
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the player hit the fall detector tag, then they are sent back to the respawn point
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        //if the player hits a crystal then the score will go up, the crystal will disapear, and the crystal sound will play
        else if (collision.tag == "Crystal")
        {
            Scoring.totalScore += 1;
            scoreText.text = Scoring.totalScore.ToString();
            collision.gameObject.SetActive(false);
            GetComponent<AudioSource>().PlayOneShot(crystal);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if the player touches the tag Spike then they will take damage
        if(collision.tag == "Spike")
        {
            healthBar.Damage(0.002f);
        }
    }
}


//https://www.youtube.com/watch?v=RYw8lAI-_Y0&list=PLGmYIROty-5YPWeXeVnQvR9KbMIrL5cM-&index=3 by Daniel Wood
