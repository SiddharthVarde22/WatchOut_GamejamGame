using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 10;
    [SerializeField]
    float moveForce = 10;

    Rigidbody2D playersRigidBody;
    Animator playerAnimator;
    SpriteRenderer playerSpriteRenderer;
    bool isJumping = false;
    bool isGrounded = true;
    float horizontalInput;
    float maxRayDistance = 0.65f;
    byte jumpNumber = 0;
    RaycastHit2D groundDetectionRay;

    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    GameObject winPanel;
    void Start()
    {
        playersRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJumping && jumpNumber < 2)
        {
            isJumping = true;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if(horizontalInput >= 0)
        {
            playerSpriteRenderer.flipX = false;
        }
        else if(horizontalInput < 0)
        {
            playerSpriteRenderer.flipX = true;
        }

        groundDetectionRay = Physics2D.Raycast(transform.position, Vector2.down, maxRayDistance, LayerMask.GetMask("Ground"));

        if(groundDetectionRay.collider != null)
        {
            if(jumpNumber > 0)
            {
                jumpNumber = 0;
            }
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        playerAnimator.SetBool("IsGrounded", isGrounded);
        if(!isGrounded)
        {
            playerAnimator.SetFloat("VerticalSpeed", playersRigidBody.velocity.y);
        }
        else
        {
            playerAnimator.SetFloat("VerticalSpeed", 0);
        }
        
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (isJumping)
        {
            playersRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
            jumpNumber++;
        }

        playersRigidBody.AddForce(Vector2.right * horizontalInput * moveForce);
        playerAnimator.SetFloat("HorizontalSpeed", horizontalInput);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
