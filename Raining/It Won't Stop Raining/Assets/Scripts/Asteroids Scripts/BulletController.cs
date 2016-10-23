using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	Vector2 bulletVel;

	public float bulletSpeed;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = bulletVel * bulletSpeed;
		Debug.Log(bulletVel);
		Debug.Log(bulletSpeed);
	}

	public void SetVelocity(Vector2 vel) {
		bulletVel = vel;
		Debug.Log("Set " + bulletVel+ " to " + vel);
	}
}
