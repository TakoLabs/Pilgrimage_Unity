using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Animator        anim;
    private Rigidbody2D     rb2d;
    private BoxCollider2D   bbox;
   
    bool facingRight = true;
    bool jump = false;
    bool isTouchingWall = false;

    public float jumpForce = 1.0f;
    public float maxSpeed = 5f;


    void Awake () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        bbox = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if (Input.GetButtonDown("Jump") && IsGrounded())
            jump = true;
    }

    void FixedUpdate () {
        float movement = Input.GetAxis("Horizontal");
        Vector2 moveVector = new Vector2(movement * maxSpeed, rb2d.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(moveVector.x));

        Debug.Log(isTouchingWall + " " + movement + " " + facingRight);

        if(!(isTouchingWall && !IsGrounded() && (movement > 0 && facingRight || (movement < 0 && !facingRight))))
            rb2d.velocity = moveVector;


        if (movement > 0 && !facingRight)
            Flip();
        else if (movement < 0 && facingRight)
            Flip();

        if (jump) {
            anim.SetTrigger("Jump");
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Collider2D collider = collision.collider;

        if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isTouchingWall = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Collider2D collider = collision.collider;

        if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                isTouchingWall = false;
    }

    bool IsGrounded() {
        int layers = LayerMask.GetMask("Ground");
        float distToGround = bbox.bounds.extents.y + 0.1f;

        return Physics2D.Raycast(transform.position, Vector2.down, distToGround, layers);
    }

    void Flip() {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
