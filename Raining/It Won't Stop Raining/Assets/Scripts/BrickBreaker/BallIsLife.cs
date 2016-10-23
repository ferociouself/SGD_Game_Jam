using UnityEngine;
using System.Collections;

public class BallIsLife : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (0, -1 * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Bouncer") {
			
		}
	}
}
