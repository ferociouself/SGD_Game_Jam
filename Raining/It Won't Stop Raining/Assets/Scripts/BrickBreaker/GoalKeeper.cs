using UnityEngine;
using System.Collections;

public class GoalKeeper : MonoBehaviour {

	bool holding;
	float timer;
	public float delay;
	public float speed;

	// Use this for initialization
	void Start () {
		timer = 0;
		holding = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (holding && timer <= 0) {
			GameObject newBoy = (GameObject)(Resources.Load ("Prefabs/BrickBreaker/Ball", typeof(GameObject)));
			GameObject.Instantiate (newBoy);
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
		}
	}
}
