using UnityEngine;
using System.Collections;

public class DogMoving : MonoBehaviour
{
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		StartCoroutine (ActivationRoutine ());
	}


	//Making dogs after timer
	private IEnumerator ActivationRoutine ()
	{        
		//Wait for 5 secs.
		yield return new WaitForSeconds (5);

		//Turn My game object that is set to false(off) to True(on).
		rb2d.velocity = new Vector2 (0f, 1f);
		yield return new WaitForSeconds (2);
		
	}


	//Trigger
	void OnTriggerEnter2D (Collider2D other)
	{
		print ("Are you Hitting?");
		print (rb2d.velocity);
		rb2d.velocity = new Vector2 (0f, 0f);
	}


	// Update is called once per frame
	void Update ()
	{
		
	}
}
