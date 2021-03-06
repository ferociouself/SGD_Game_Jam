﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PigeonFactory : MonoBehaviour {

	public float PigeonsPerMinute;
	float secondsPerPigeon;
	public string[] prefabs; //Paths to the prefabs to toss around!
	float pigeonCooldown;
	public Texture2D cursor;
	public float TimeLimit;
	public AudioSource hitSound;

	// Use this for initialization
	void Start () {
		secondsPerPigeon = 60f / PigeonsPerMinute;
		pigeonCooldown = secondsPerPigeon;
	}
	
	// Update is called once per frame
	void Update () {
		if (pigeonCooldown <= 0) {
			pigeonCooldown = secondsPerPigeon;
			spawnPigeon ();
		} else {
			pigeonCooldown -= Time.deltaTime;
		}
		TimeLimit -= Time.deltaTime;
		GameObject.Find ("Canv2").GetComponentInChildren<Text> ().text = ((int)(TimeLimit)).ToString();
		if(TimeLimit <= 0){
			//End Game!!!!!!!
			SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
			SM.MoveToScene (0);
		}
	}

	void OnEnable(){
		Cursor.SetCursor (cursor, new Vector2 (0, 0), CursorMode.Auto);
	}

	void OnDisable(){
		Cursor.SetCursor (null, new Vector2 (0, 0), CursorMode.Auto);
	}

	void spawnPigeon(){
		GameObject nextSpawn = (GameObject)(Resources.Load ("Prefabs/DuckHunt/" + prefabs [Random.Range (0, prefabs.Length)], typeof(GameObject)));
		//Debug.Log (toSpawn);
		int negativeX = Random.Range (0, 2) * 2 - 1;
		nextSpawn.transform.position = new Vector2 (negativeX * 4,Random.value * 2 - 1);
		GameObject toSpawn = GameObject.Instantiate (nextSpawn);
		toSpawn.GetComponent<Pigeon>().setXY(-1 * negativeX * (Random.value * 4 + 2),Random.value * 2 + 1);
		toSpawn.GetComponent<Pigeon> ().ospeed = Random.value * 30 + 20;
		toSpawn.GetComponent<Pigeon> ().hitsound = hitSound;
	}
}
