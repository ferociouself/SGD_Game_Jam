using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pigeon : MonoBehaviour {

	public float ospeed; //Speed of rotation in degrees/second
	float xSpeed; //Horizontal Speed
	float yInitialSpeed; //Initial Y speed
	public Rigidbody2D rb;
	public AudioSource hitsound;

	char[] c = { ' ' };

	public int value;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (xSpeed, yInitialSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		rb.transform.Rotate (0, 0, ospeed * Time.deltaTime);
		if (rb.transform.position.y < -4) {
			Destroy (this.gameObject);
		}
	}

	void OnMouseDown(){
		rb.velocity = new Vector2 (0, 2);
		ospeed = 180;
		Destroy (GetComponent<Collider2D> ());
		//Add points, make sound here.
		hitsound.Play();

		string curr = GameObject.Find("Canv").GetComponentInChildren<Text> ().text;
		string[] spliced = curr.Split (c, 2);
		int i = int.Parse (spliced [1]);
		i += value;
		GameObject.Find("Canv").GetComponentInChildren<Text> ().text = "Score: " + i.ToString ();
	}

	public void setXY(float x,float y){
		xSpeed = x;
		yInitialSpeed = y;
		rb.AddForce (new Vector2 (x * 10, y * 10));
		//Debug.Log ("SET:" + x + ":" + y);
		//Debug.Log (rb.velocity);
	}
}
