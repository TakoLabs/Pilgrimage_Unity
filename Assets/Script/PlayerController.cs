using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PawnController
{
    private Animator        anim;
   
    bool facingRight = true;
    bool jump = false;
    bool isTouchingWall = false;

    public float jumpForce = 1.0f;
    public float maxSpeed = 5f;


    void Awake ()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
            jump = true;
    }

    void FixedUpdate ()
    {
        float movement = Input.GetAxis("Horizontal");
        Vector2 moveVector = new Vector2(movement * maxSpeed, this.rigidBody.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(moveVector.x));

        Debug.Log(isTouchingWall + " " + movement + " " + facingRight);

        if(!(isTouchingWall && !IsGrounded() && (movement > 0 && facingRight || (movement < 0 && !facingRight))) && moveVector.x != 0)
            this.rigidBody.velocity = moveVector;


        if (movement > 0 && !facingRight)
            Flip();
        else if (movement < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump");
            this.rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isTouchingWall = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                isTouchingWall = false;
    }

    bool IsGrounded()
    {
        int layers = LayerMask.GetMask("Ground");
        float distToGround = this.collider.bounds.extents.y + 0.1f;

        return Physics2D.Raycast(transform.position, Vector2.down, distToGround, layers);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public override void Move()
    {
        
    }
}
