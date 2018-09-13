using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	public PlayerControllerB Para;
	Animator anim;


	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs (Para.move));
		if (Input.GetButton("ButtonA")) {
			anim.SetTrigger ("Jump");
		}
	}
}
