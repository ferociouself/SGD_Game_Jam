using UnityEngine;
using System.Collections;

public class Throb : MonoBehaviour {

	public float tempo;
	public float scale;
	public float LERP_TIME = 0.5f;

	float timeSinceLast;
	Vector3 initPos;
	Vector3 finalPos;
	float transTime = 0.0f;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		timeSinceLast = Time.time;
		finalPos = gameObject.transform.localScale;
		initPos = new Vector3(scale, scale, 1.0f);
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		timeSinceLast += Time.deltaTime;
		if (timeSinceLast >= 60/tempo) {
			if (RavageMe ()) {
				timeSinceLast = 0;
			}
		}
	}

	private bool RavageMe() {

		float timerVal = transTime / LERP_TIME;

	    this.gameObject.transform.localScale = Vector3.Lerp(this.initPos, this.finalPos, timerVal);

		if (transTime >= LERP_TIME) {
			gameObject.transform.localScale = finalPos;
			transTime = 0.0f;
			return true;
		}  else {
			transTime += Time.deltaTime;
			return false;
		}
	}
}
