using UnityEngine;
using System.Collections;

public class Endgame : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//End Dat GAme
			SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
			SM.MoveToScene (0);
		}
	}
}

