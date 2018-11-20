using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PawnController : MonoBehaviour, IMoveable
{
    protected Rigidbody2D       rigidBody;
    protected new Collider2D    collider;

    void Start ()
    {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.collider = GetComponent<Collider2D>();
    }
	
	void Update () {

    }

    public abstract void Move();
}
