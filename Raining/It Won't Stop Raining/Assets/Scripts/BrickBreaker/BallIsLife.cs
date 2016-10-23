using UnityEngine;
using System.Collections;

public class BallIsLife : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (0, -1 * speed);
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity *= 0.9f;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Bouncer") {
			/*float xdif = transform.position.x - other.gameObject.transform.position.x;
			float currTheta = Mathf.Atan2 (rb.velocity.y, rb.velocity.x);
			float nextTheta = currTheta - /*2 * /*Mathf.Acos(/xdif/* / 1.28f);
			rb.velocity = (new Vector2 (Mathf.Cos(nextTheta),Mathf.Sin(nextTheta))) * rb.velocity.magnitude;*/
		}
	}
}
