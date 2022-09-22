using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private float moveInput;

    private bool isGrounded;
    private bool isFacingRight = true;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public float gravityScaleAfterChange;
    public Needle needle;

    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(moveInput==0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }
    void Update()
    {
        Flip();
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded==true)
        {
            rb.gravityScale = 3;
        }
        if (isGrounded==false && Input.GetKey(KeyCode.S))
        {
            rb.gravityScale = gravityScaleAfterChange;
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
    }
    private void Flip()
    {
        if(isFacingRight && moveInput <0f || !isFacingRight && moveInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
