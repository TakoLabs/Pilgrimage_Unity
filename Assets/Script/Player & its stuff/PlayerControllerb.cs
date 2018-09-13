using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<>
public class PlayerControllerB : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	Rigidbody2D rb;
	public Animator anim;
	public float move;
	public int c = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		move = Input.GetAxis ("LeftHorizontal");
		//Animation ();
		//anim.SetFloat ("Speed", Mathf.Abs(move));
		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		if (Input.GetButtonDown("ButtonA") && c == 0) {
			//float veloy = rb.velocity.y +200;
			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y + 12);
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 thescale = transform.localScale;
		thescale.x *= -1;
		transform.localScale = thescale;
	}


		
}
