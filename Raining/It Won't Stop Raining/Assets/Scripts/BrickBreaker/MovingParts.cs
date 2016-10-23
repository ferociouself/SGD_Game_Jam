using UnityEngine;
using System.Collections;

public class MovingParts : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Left")) {
			rb.velocity = new Vector2 (-speed, 0);
		} else if (Input.GetButton ("Right")) {
			rb.velocity = new Vector2 (speed, 0);
		} else {
			rb.velocity = new Vector2 (0, 0);
		}
	}
}
