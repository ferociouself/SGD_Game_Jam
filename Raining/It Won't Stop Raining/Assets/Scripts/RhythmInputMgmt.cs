using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RhythmInputMgmt : MonoBehaviour {

	public GameObject UpCircle;
	public GameObject RightCircle;
	public GameObject LeftCircle;
	public GameObject DownCircle;

	public int Difficulty;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Up")){
			//Debug.Log("Pressed Up");
			bool hit = false;
			foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
				if (StaticMethods.AlmostEquals((Vector2)(obj.transform.position), (Vector2)(Camera.main.ScreenToWorldPoint(UpCircle.transform.position)), Difficulty)) {
					//hit
					hit = true;
					break;
				}
			}
			if (!hit) {
				//swing and a miss!
			}
		}

		if(Input.GetButtonDown("Right")){
			//Debug.Log("Pressed Right");
			bool hit = false;
			foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
				if (StaticMethods.AlmostEquals(obj.transform.position, Camera.main.ScreenToWorldPoint(RightCircle.transform.position), Difficulty)) {
					//hit
					break;
				}
			}
			if (!hit) {
				//swing and a miss!
			}
		}

		if(Input.GetButtonDown("Down")){
			//Debug.Log("Pressed Down");
			bool hit = false;
			foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
				if (StaticMethods.AlmostEquals(obj.transform.position, Camera.main.ScreenToWorldPoint(DownCircle.transform.position), Difficulty)) {
					//hit
					break;
				}
			}
			if (!hit) {
				//swing and a miss!
			}
		}

		if(Input.GetButtonDown("Left")){
			//Debug.Log("Pressed Left");
			bool hit = false;
			foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
				if (StaticMethods.AlmostEquals(obj.transform.position, Camera.main.ScreenToWorldPoint(LeftCircle.transform.position), Difficulty)) {
					//hit
					break;
				}
			}
			if (!hit) {
				//swing and a miss!
			}
		}
	}
}
