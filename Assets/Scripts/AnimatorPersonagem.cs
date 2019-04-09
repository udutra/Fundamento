using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPersonagem : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    public Transform groundCheck;
    private bool isGrounded;
    private int speedX;
    private float speedY;
    public float speed;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            speedX = 1;
        }
        else
        {
            speedX = 0;
        }
        speedY = playerRb.velocity.y;
        playerRb.velocity = new Vector2(horizontal * speed, speedY);
    }

    private void LateUpdate()
    {
        playerAnimator.SetInteger("speedX", speedX);
        playerAnimator.SetFloat("speedY", speedY);
        playerAnimator.SetBool("grounded", isGrounded);
    }
}
