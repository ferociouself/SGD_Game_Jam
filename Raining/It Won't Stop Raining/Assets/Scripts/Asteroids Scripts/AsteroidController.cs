using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

	public enum AsteroidSize {
		Yuge,
		Huge,
		Big,
		Medium,
		Small,
		Tiny
	}

	public AsteroidSize size;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag("Projectile")) {

		}
	}

	void Split() {

	}
}
