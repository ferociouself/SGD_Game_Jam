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
		rb.velocity = new Vector2 (speed * Input.GetAxis ("Horizontal"), 0);
	}
}
