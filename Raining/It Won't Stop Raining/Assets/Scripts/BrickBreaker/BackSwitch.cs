using UnityEngine;
using System.Collections;

public class BackSwitch : MonoBehaviour {

	public Sprite off,on;
	bool isOn;

	// Use this for initialization
	void Start () {
		isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Toggle(){
		isOn = !isOn;
		GetComponent<SpriteRenderer>().sprite = isOn? on : off;
	}
}
