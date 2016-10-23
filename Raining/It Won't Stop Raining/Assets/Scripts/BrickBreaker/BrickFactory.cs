using UnityEngine;
using System.Collections;

public class BrickFactory : MonoBehaviour {

	public int layers;

	// Use this for initialization
	void Start () {
		for (int j = 0; j < layers; j++) {
			for (int i = 0; i < 25; i++) {
				spawnBrick (new Vector2(-7.68f + (0.64f * i),4.34f - (0.32f * j)));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnBrick(Vector2 position){
		GameObject newBoi = (GameObject)(Resources.Load ("Prefabs/BrickBreaker/Brick", typeof(GameObject)));
		newBoi.transform.position = position;
		GameObject.Instantiate (newBoi);
	}
}
