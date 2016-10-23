using UnityEngine;
using System.Collections;

public class WalkSounds : MonoBehaviour {

	public AudioSource a; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void WalkSound(){
		a.Play ();
	}
}
