using UnityEngine;
using System.Collections;

public class LiveAndBreathe : MonoBehaviour {

	/// <summary>
	/// The start time.
	/// </summary>
	float startTime;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () { }

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable() {
		this.startTime = Time.time;
	}

	/// <summary>
	/// Gets the start time.
	/// </summary>
	/// <returns>The start time.</returns>
	public float getStartTime(){
		return this.startTime;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () { }
}
