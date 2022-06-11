﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float moveSpeed = 7f;
	Rigidbody2D rb;
	GameObject target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		target = GameObject.FindGameObjectWithTag("Player");
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, 3f);
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			Debug.Log ("Hit!");
			Destroy (gameObject);
		}
	}

}
