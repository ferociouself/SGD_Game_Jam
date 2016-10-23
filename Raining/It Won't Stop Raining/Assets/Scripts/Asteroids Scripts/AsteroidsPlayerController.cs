using UnityEngine;
using System.Collections;

public class AsteroidsPlayerController : MonoBehaviour {

	public float speed;

	Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float curRot = gameObject.transform.rotation.eulerAngles.z;

		Vector2 force = new Vector2(Mathf.Sin(Mathf.Deg2Rad * curRot), -Mathf.Cos(Mathf.Deg2Rad * curRot));

		if (Input.GetButton("Up")) {
			rb.AddForce(force * -speed);
		}
		if (Input.GetButton("Down")) {
			rb.AddForce(force * speed);
		}

		if (Input.GetButton("Right")) {
			rb.angularVelocity = -speed * 20;
		}
		else if (Input.GetButton("Left")) {
			rb.angularVelocity = speed * 20;
		}


	}
}
