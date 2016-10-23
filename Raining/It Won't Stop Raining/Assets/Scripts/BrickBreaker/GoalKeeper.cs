using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalKeeper : MonoBehaviour {

	bool holding;
	float timer;
	public float delay;
	public float speed;
	public Text liveCounter;
	public int lives;

	// Use this for initialization
	void Start () {
		timer = 0;
		holding = false;
		liveCounter.text = "Lives: " + lives.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (holding && timer <= 0) {
			GameObject newBoi = (GameObject)(Resources.Load ("Prefabs/BrickBreaker/Ball", typeof(GameObject)));
			GameObject.Instantiate (newBoi);
			holding = false;
		}
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Ball") {
			timer = delay;
			Destroy (other.gameObject);
			holding = true;
			decrementLives ();
		}
	}

	void decrementLives(){
		lives--;
		liveCounter.text = "Lives: " + lives.ToString ();
		if (lives <= 0) {
			//End of Game!!!
		}
	}
}
