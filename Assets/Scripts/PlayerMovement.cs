using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    private float direction;
    public float jumpForce;
    private Rigidbody2D rb;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayers;
    private bool isGrounded;

    public SpriteRenderer sr;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // If not paused we should be able to do.
        if (!PauseMenu.instance.isPaused)
        {

             
        // accessing player movement horizontally
           direction = Input.GetAxis("Horizontal");
           rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        // check if player on the ground
           isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

          if(Input.GetButtonDown("Jump") && isGrounded)
          {
             rb.velocity = new Vector2(rb.velocity.x, jumpForce);
          }

        // check if character moving to left, it should turn his face.
          if(rb.velocity.x < 0)
          {
            sr.flipX = true;
          }
          else if(rb.velocity.x > 0) 
          {
            sr.flipX = false;
          }

        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);



    }

    // when we touch moving platform our player will be child of this.
    // it is necessary for staying at the top of the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
