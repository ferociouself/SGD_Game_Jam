using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RhythmInputMgmt : MonoBehaviour {

	/**TODO:
	 * Make nodes to actual song
	 * make scoring system based on hits and misses
	 * make UI throb to the beat
	 **/

	public GameObject UpCircle;
	public GameObject RightCircle;
	public GameObject LeftCircle;
	public GameObject DownCircle;

	//Vector2 screenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

	public float Difficulty;
	public float BASE_F; //for scoring

	private float time;

	long score;
	public GameObject textField;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		score = 0;
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
			bool hit = false;
			foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
				if (StaticMethods.AlmostEquals((Vector2)(obj.transform.position), (Vector2)(Camera.main.ScreenToWorldPoint(UpCircle.transform.position)), Difficulty)) {
					//hit
					IncrementScore((int)(BASE_F * Mathf.Sqrt(time) * Random.Range(1.0f, 3.0f)));
					hit = EmitAndDestroy (obj);
					break;
				}
			}
			if (!hit) {
				IncrementScore ((int)((-1.00 * (BASE_F / 2.0f) * Mathf.Sqrt (Mathf.Sqrt (time))) * Random.Range (1.0f, 2.0f)));
			}
		}

		if(Input.GetButtonDown("Right")){
			bool hit = false;
			foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
				if (StaticMethods.AlmostEquals((Vector2)(obj.transform.position), (Vector2)(Camera.main.ScreenToWorldPoint(RightCircle.transform.position)), Difficulty)) {
					//hit
					IncrementScore((int)(BASE_F * Mathf.Sqrt(time) * Random.Range(1.0f, 3.0f)));
					hit = EmitAndDestroy (obj);
					break;
				}
			}
			if (!hit) {
				IncrementScore ((int)((-1.00 * (BASE_F / 2.0f) * Mathf.Sqrt (Mathf.Sqrt (time))) * Random.Range (1.0f, 2.0f)));
			}
		}

		if(Input.GetButtonDown("Down")){
			bool hit = false;
			foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
				if (StaticMethods.AlmostEquals((Vector2)(obj.transform.position), (Vector2)(Camera.main.ScreenToWorldPoint(DownCircle.transform.position)), Difficulty)) {
					//hit
					IncrementScore((int)(BASE_F * Mathf.Sqrt(time) * Random.Range(1.0f, 3.0f)));
					hit = EmitAndDestroy (obj);
					break;
				}
			}
			if (!hit) {
				IncrementScore ((int)((-1.00 * (BASE_F / 2.0f) * Mathf.Sqrt (Mathf.Sqrt (time))) * Random.Range (1.0f, 2.0f)));
			}
		}

		if(Input.GetButtonDown("Left")){
			bool hit = false;
			foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
				if (StaticMethods.AlmostEquals((Vector2)(obj.transform.position), (Vector2)(Camera.main.ScreenToWorldPoint(LeftCircle.transform.position)), Difficulty)) {
					//hit
					IncrementScore((int)(BASE_F * Mathf.Sqrt(time) * Random.Range(1.0f, 3.0f)));
					hit = EmitAndDestroy (obj);
					break;
				}
			}
			if (!hit) {
				IncrementScore((int)((-1.00 * (BASE_F/2.0f) * Mathf.Sqrt(Mathf.Sqrt(time))) * Random.Range(1.0f, 2.0f)));
			}
		}

		foreach (GameObject obj in gameObject.GetComponent<RhythmController>().getDeployed()) {
			if (!(obj.GetComponent<SpriteRenderer>().isVisible)
				&& obj.GetComponent<LiveAndBreathe>().getStartTime() < this.time + 3) {
				//swing and a miss!
				//IncrementScore((int)(-1.00 * (int)(BASE_F * Mathf.Sqrt(time) * Random.Range(1.0f, 3.0f))));
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
		return gameObject.GetComponent<RhythmController> ().getDeployed ().Remove(obj);
	}

	private void IncrementScore(int incr){
		score += incr;
		textField.GetComponent<Text>().text = ("Score: " + score.ToString());
	}
}
