using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RhythmInputMgmt : MonoBehaviour {

	/**TODO:
	 * Make nodes to actual song
	 * remove deployed when they fall off screen***
	 * make scoring system based on hits and misses
	 * make UI throb to the beat
	 **/

	public GameObject UpCircle;
	public GameObject RightCircle;
	public GameObject LeftCircle;
	public GameObject DownCircle;

	public int Difficulty;

	private float time;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
	
	}

	/// <summary>
	/// Raises the enabled event.
	/// </summary>
	void OnEnabled () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if(Input.GetButtonDown("Up")){
			//Debug.Log("Pressed Up");
			bool hit = false;
			foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
				if (StaticMethods.AlmostEquals((Vector2)(obj.transform.position), (Vector2)(Camera.main.ScreenToWorldPoint(UpCircle.transform.position)), Difficulty)) {
					//hit
					hit = EmitAndDestroy (obj);
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
				if (StaticMethods.AlmostEquals((Vector2)(obj.transform.position), (Vector2)(Camera.main.ScreenToWorldPoint(RightCircle.transform.position)), Difficulty)) {
					//hit
					hit = EmitAndDestroy (obj);
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
				if (StaticMethods.AlmostEquals((Vector2)(obj.transform.position), (Vector2)(Camera.main.ScreenToWorldPoint(DownCircle.transform.position)), Difficulty)) {
					//hit
					hit = EmitAndDestroy (obj);
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
				if (StaticMethods.AlmostEquals((Vector2)(obj.transform.position), (Vector2)(Camera.main.ScreenToWorldPoint(LeftCircle.transform.position)), Difficulty)) {
					//hit
					hit = EmitAndDestroy (obj);
					break;
				}
			}
			if (!hit) {
				//swing and a miss!
			}
		}

		foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
			//Debug.Log (StaticMethods.AlmostEquals (obj.GetComponent<LiveAndBreathe> ().getStartTime (), this.time, 1.0f));
			//Debug.Log ("ST: "+ obj.GetComponent<LiveAndBreathe> ().getStartTime ().ToString());
			//Debug.Log ("Time: " + this.time.ToString());
			if (!obj.GetComponent<SpriteRenderer> ().isVisible 
				&& !StaticMethods.AlmostEquals(obj.GetComponent<LiveAndBreathe>().getStartTime(), this.time, 1.0f)) {
				//swing and a miss!
				DestroyPlz(obj);
				break;
			}
		}
	}

	private bool EmitAndDestroy(GameObject obj){
		obj.GetComponent<ParticleSystem> ().Emit (75);
		obj.GetComponent<SpriteRenderer>().enabled = false;
		return DestroyPlz(obj);
	}

	private bool DestroyPlz(GameObject obj){
		Object.Destroy (obj, 2.0f);
		return gameObject.GetComponent<RhythmController> ().getDeployed ().Remove (obj);
	}
}
