using UnityEngine;
using System.Collections.Generic;

public class RoomTrigger : MonoBehaviour {


	public float dimfactor, darkfactor;
    public List<GameObject> items;

	private Color dark, dim, lit, target, last;

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
        foreach(GameObject go in items)
            go.GetComponent<SpriteRenderer>().color = Color.Lerp(last, target, Mathf.PingPong(Time.time, 20));
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
