using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;
	public float jumpForce = 1.0f;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float horiz = Input.GetAxis("Horizontal") * speed;

		rb.velocity = new Vector2(horiz, rb.velocity.y);

		if (rb.velocity.magnitude > 0.1) {
			gameObject.GetComponent<Animator>().SetBool("Moving", true);
		} else {
			gameObject.GetComponent<Animator>().SetBool("Moving", false);
		}

		if (rb.velocity.x > 0) {
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
		} else {
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}

		if (Input.GetButtonDown("Jump")) {
			rb.AddForce(Vector2.up * jumpForce);
		}
	}
}
