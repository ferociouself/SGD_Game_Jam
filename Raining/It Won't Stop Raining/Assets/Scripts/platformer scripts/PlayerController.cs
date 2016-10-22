using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Vertical") > 0 && rb.velocity.y == 0) {
			rb.velocity = new Vector2(rb.velocity.x,5);
		}
		rb.velocity = new Vector2(Input.GetAxis("Horizontal")*4,rb.velocity.y);
	}
}
