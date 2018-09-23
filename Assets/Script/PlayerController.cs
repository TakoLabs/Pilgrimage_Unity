using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Animator        anim;
    private Rigidbody2D     rb2d;

    bool facingRight = true;
    bool jump = false;

    public float moveForce = 1.0f;
    public float jumpForce = 1.0f;
    public float maxSpeed = 5f;


    void Awake () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    void FixedUpdate () {
        float movement = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(movement));

        if (rb2d.velocity.x * movement < maxSpeed)
            rb2d.AddForce(Vector2.right * movement * moveForce, ForceMode2D.Force);


        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

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

    void Flip() {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
