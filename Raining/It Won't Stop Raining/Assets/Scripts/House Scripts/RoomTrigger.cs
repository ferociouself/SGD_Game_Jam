using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {

	private Color dark;
	private Color dim;
	private Color lit;

	public float dimfactor;
	public float darkfactor;

	private Color target;
	private Color last;

	// Use this for initialization
	void Start () {
		dark = new Color(darkfactor, darkfactor, darkfactor, 1f);
		dim = new Color(dimfactor, dimfactor, dimfactor, 1f);
		lit = new Color (255f,255f,255f,255f);
		this.GetComponent<SpriteRenderer> ().color = dark;
		last = dark;
		target = dark;
	}

	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.Lerp (last, target, Mathf.PingPong(Time.time, 20));
	}

	void OnTriggerEnter2D (Collider2D coll) {
		last = target;
		target = lit;
	}

	void OnTriggerExit2D(Collider2D coll) {
		last = target;
		target = dim;
	}
		
}
