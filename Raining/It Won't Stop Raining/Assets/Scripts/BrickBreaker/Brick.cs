using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Brick : MonoBehaviour {

	public int pointValue;
	public Text scoreBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Ball") {
			sendPoints ();
			Destroy (this.gameObject);
		}
	}

	void sendPoints(){
		//Score Points?
		string curr = scoreBox.text;
		string[] currParts = curr.Split(new char[]{' '},2);
		int currScore = int.Parse(currParts[1]);
		scoreBox.text = currParts[0] + " " + (currScore + pointValue);
	}
}
