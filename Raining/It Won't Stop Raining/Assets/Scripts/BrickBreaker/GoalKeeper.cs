using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GoalKeeper : MonoBehaviour {

	bool holding;
	float timer;
	public float delay;
	public float speed;
	public int lives;
	List<GameObject> liveList;

	// Use this for initialization
	void Start () {
		timer = 0;
		holding = false;
		liveList = new List<GameObject> ();
		for (int i = 0; i < lives; i++) {
			GameObject newBoi = (GameObject)(Resources.Load ("Prefabs/BrickBreaker/Life",typeof(GameObject)));
			newBoi.transform.position = new Vector2 (-1.74f + (i * .12f),-1.55f);
			liveList.Add (GameObject.Instantiate (newBoi));
		}
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
		liveList [liveList.Count - 1].SetActive (false);
		liveList.Remove (liveList[liveList.Count - 1]);
		if (lives <= 0) {
			//End of Game!!!
			SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
			SM.MoveToScene (0);
		}
	}
}
