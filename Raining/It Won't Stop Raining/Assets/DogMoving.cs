using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DogMoving : MonoBehaviour
{
	private Rigidbody2D rb2d;
	private bool isPaused;
	private int state;
	public float speed;
	private GameObject Dest;
	public GameObject Entrance;
	public GameObject Exit;
	public GameObject[] possibleDests;
	public Text Lose;
	private PlayerMovementHAS playerScript;
	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		StartCoroutine (Pause (5));
		state = 0;
		Lose.text = "";
		Dest = Entrance;
		playerScript = GameObject.Find ("Player").GetComponent<PlayerMovementHAS> ();
	}
		
	//Making dogs after timer
	private IEnumerator Pause (int time)
	{        
		isPaused = true;
		//Wait for 5 secs.
		yield return new WaitForSeconds (time);

		//Turn My game object that is set to false(off) to True(on).
		isPaused = false;
	}

	//Making dogs after timer
	private IEnumerator RestartGamePause (int time)
	{        
		//Wait for 5 secs.
		yield return new WaitForSeconds (time);

		Application.LoadLevel ("HideAndSeek");
	}

	void isFound ()
	{
		Lose.text = "You Lose";
		StartCoroutine (RestartGamePause (5));
		Dest = null;
		state = 5;
	}

	bool found ()
	{
		return Dest == playerScript.currentHidingSpot;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject == Dest) {
			GameObject newDest;
			switch (state) {
			case 0:
				StartCoroutine (Pause (2));
				do {
					int index = (int)Random.Range (0, 5);
					newDest = possibleDests [index];
				} while (newDest == Dest);
				Dest = newDest;
				break;
			case 1:
				if (found ()) {
					isFound ();
					break;
				}
				StartCoroutine (Pause (2));
				do {
					int index = (int)Random.Range (0, 5);
					newDest = possibleDests [index];
				} while (newDest == Dest);
				Dest = newDest;
				break;
			case 2:
				if (found ()) {
					isFound ();
					break;
				}
				StartCoroutine (Pause (2));
				Dest = Entrance;
				break;
			case 3:
				StartCoroutine (Pause (2));
				Dest = Exit;
				break;
			case 4:
				// game finished
				break;
			}
			state++;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!isPaused && Dest != null) {
			Vector2 destPos = Dest.transform.position;
			transform.position = Vector2.MoveTowards (transform.position, destPos, speed * Time.deltaTime);
		}
	}
}
