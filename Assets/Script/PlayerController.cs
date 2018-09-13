using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float            maxSpeed;

    private Animator        anim;
    private Rigidbody2D     rb2d;

    bool facingRight = true;

    void Awake () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	void FixedUpdate () {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

        float movement = Input.GetAxis("Horizontal");


    }
}
