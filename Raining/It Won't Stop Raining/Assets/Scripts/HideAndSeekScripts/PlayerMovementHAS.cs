using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovementHAS : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb2d;
	private bool hiding = false;
	bool justHidden = false;
	bool colliding = false;
	public Text timer;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		timer.text = "Timer: ";
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		colliding = true;
	}

	void OnTriggerExit2D (Collider2D other)
	{
		colliding = false;
	}

	void Hide ()
	{
		justHidden = true;
		gameObject.GetComponent<SpriteRenderer> ().enabled = !gameObject.GetComponent<SpriteRenderer> ().enabled;
		hiding = !hiding;
	}

	// Update is called once per frame
	void Update ()
	{
		float timeLeft = 15 - Time.deltaTime;
		timer.text = "Timer: " + timeLeft.ToString ();
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (!hiding && colliding) {
			if (Input.GetButtonDown ("Activate")) {
				Hide ();
			}
		}
		if (!hiding)
			rb2d.velocity = new Vector2 (moveHorizontal * speed, moveVertical * speed);
		else if (!justHidden) {
			if (Input.GetButtonDown ("Activate")) {
				Hide ();
			}
		}
		if (justHidden) {
			justHidden = false;
		}

	}
}