using UnityEngine;
using System.Collections;

public class Throb : MonoBehaviour {

	public float tempo;
	public float timeSinceLast;

	// Use this for initialization
	void Start () {
		timeSinceLast = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLast += Time.deltaTime;
		if (timeSinceLast >= tempo / 60) {
			ThrobMe ();
			timeSinceLast = 0;
		}
	}

	private void ThrobMe(){
		//Mathf.Lerp(
	}
}
