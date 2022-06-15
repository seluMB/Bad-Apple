using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float moveSpeed = 7f;
	public Rigidbody2D rb;
	GameObject target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		target = GameObject.FindGameObjectWithTag("Player");
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x,0);
		Destroy (gameObject, 3f);
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Environment")
		{
			Debug.Log("Hit!");
			Destroy(gameObject);

		}

	}

}
