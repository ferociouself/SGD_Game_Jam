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
	float timeLeft;
	bool firstTimeComplete;
	bool secondTimeComplete;
	bool canControl;
	float moveHorizontal;
	float moveVertical;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		timer.text = "Timer: ";
		timeLeft = 15;
		firstTimeComplete = false;
		secondTimeComplete = false;
		canControl = true;
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
		//Make it so that the timer counts down. Once when the inaugural timer ends, the second timer starts. The player object
		//may not move. If the player is not hiding then the dog immediately goes to the player. Once when the Second timer
		//hits 0, the dog leaves and the boy's sprite rendered is rendered again.

		//Makes timer decrement. For all timers
		timeLeft -= Time.deltaTime; 

		//If the inaugural timer hits 0. reset timer to 30 and make first time to ture and disable controls
		if (timeLeft <= 0 && firstTimeComplete == false) {
			timeLeft = 30f;
			firstTimeComplete = true;
			canControl = false;
		}
		if (firstTimeComplete == true) {
			rb2d.velocity = Vector3.zero;
			rb2d.Sleep ();
		}
		//If the second timer hits 0, disable the timer
		if (timeLeft <= 0 && firstTimeComplete == true && secondTimeComplete == false) {
			timer.enabled = false;
		}

		//Do the ceiliing of the timer
		timer.text = "Timer: " + (int)Mathf.Ceil (timeLeft);
		//If the player can be controlled i.e. the first timer hasn't ended, move the player
		if (canControl) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		}
		//If the player is not hiding and is touching a hidable object then hit 'e' and then hide the object and make the 
		//Velocity 0
		if (!hiding && colliding) {
			if (Input.GetButtonDown ("Activate")) {
				Hide ();
				//Print if the object is hiding
				print ("Hiding: " + hiding);
				print ("Just Hidden: " + justHidden);

				rb2d.velocity = Vector3.zero;
				rb2d.Sleep ();
			}
		}

		//If the Player is not 0 then make the velocity = to the movement * speed.
		//Else if hiding then hit 'e' to unhide the object
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