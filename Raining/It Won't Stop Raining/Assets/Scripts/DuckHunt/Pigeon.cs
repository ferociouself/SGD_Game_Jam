using UnityEngine;
using System.Collections;

public class Pigeon : MonoBehaviour {

	public float ospeed; //Speed of rotation in degrees/second
	public float xSpeed; //Horizontal Speed
	public float yInitialSpeed; //Initial Y speed
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (xSpeed, yInitialSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		rb.transform.Rotate (0, 0, ospeed * Time.deltaTime);
	}

	void OnMouseDown(){
		rb.velocity = new Vector2 (0, rb.velocity.y);
		//Add points, make sound here.
	}
}
