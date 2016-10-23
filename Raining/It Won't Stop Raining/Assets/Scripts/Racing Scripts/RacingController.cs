using UnityEngine;
using System.Collections;

public class RacingController : MonoBehaviour {

	public float speed;

	Rigidbody2D rb;

	bool passedCheckpoint;

	public AudioSource rev;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		rev.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		//memes
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

		rev.pitch = rb.velocity.magnitude;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.name == "Halfway Checkpoint") {
			passedCheckpoint = true;
			Debug.Log("Player Passed Checkpoint");
		}
		if (coll.gameObject.name == "Finish Line" && passedCheckpoint) {
			Debug.Log("Player Wins!");
			// Player End Game
			SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
			SM.MoveToScene (0);
		}
	}
}
