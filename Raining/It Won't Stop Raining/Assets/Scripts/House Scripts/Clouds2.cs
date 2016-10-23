using UnityEngine;
using System.Collections;

public class Clouds2 : MonoBehaviour {

	public float speed = 1;
	Vector3 start;
	float total, width;

	// Use this for initialization
	void Start () {
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();
		start = transform.position;
		total = 0;

		width = sr.sprite.bounds.size.x;
	}

	// Update is called once per frame
	void Update () {
		total += speed/500;
		if (total > width)
			total = width - total;
		transform.position = new Vector3 (start.x + total, start.y, start.z);
	}
}
