using UnityEngine;
using System.Collections;

public class TicTacToeManager : MonoBehaviour {

	GameObject[][] tiles;

	bool playerTurn;
	float turnDelay;

	// Use this for initialization
	void Start () {
		Vector2 pos = gameObject.transform.position;
		tiles = new GameObject[3][];
		for (int i = 0; i < tiles.Length; i++) {
			tiles [i] = new GameObject[3];
			for (int j = 0; j < tiles [i].Length; j++) {
				GameObject tile = (GameObject)(Resources.Load ("Prefabs/TicTacToe/TicTacTile", typeof(GameObject)));
				tile.transform.position = pos + new Vector2 (i,j);
				GameObject.Instantiate (tile);
				var ttt = tile.GetComponent<TicTacTile> ();
				ttt.x = i;
				ttt.y = j;
				ttt.parent = this;
			}
		}
		playerTurn = true;
		turnDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!playerTurn) {
			if (turnDelay <= 0) {

			} else {

			}
		}
	}

	public void handleClick(TicTacTile t){
		if (playerTurn && t.state == 0) {
			t.state = 1;
			t.GetComponent<SpriteRenderer> ().sprite = t.xImage;
			playerTurn = false;
			turnDelay = 1f;
		}
		if (isEndOfGame ()) {
			Debug.Log ("END");
		}
	}
}
