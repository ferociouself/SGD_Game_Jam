using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;
	public float jumpForce = 1.0f;

	public float timer;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		timer = 0.00f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < 5.00f) {
			timer += Time.deltaTime;
		}

		if (timer >= 0.20f && timer < 0.50f) {
			SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager> ();
			this.gameObject.transform.position = SM.getPlayerPos ();
		}

		float horiz = Input.GetAxis("Horizontal") * speed;

		rb.velocity = new Vector2(horiz, rb.velocity.y);

		if (Input.GetButtonDown("Jump")) {
			rb.AddForce(Vector2.up * jumpForce);
		}
	}
}
