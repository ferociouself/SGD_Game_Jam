using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float speed = 1.0f;
	public float jumpForce = 1.0f;

	Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horiz = Input.GetAxis ("Horizontal") * speed;

		rb.velocity = new Vector2 (horiz, rb.velocity.y);

		if (Input.GetButtonDown ("Jump")) {
			rb.AddForce (Vector2.up * jumpForce);
		}
	}
}
