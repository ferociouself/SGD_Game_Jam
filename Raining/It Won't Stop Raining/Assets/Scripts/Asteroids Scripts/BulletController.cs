using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	Vector2 bulletVel;

	public float bulletSpeed;

	Rigidbody2D rb;

	public float timeLasted;
	float curTime;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (curTime >= timeLasted) {
			Destroy(gameObject);
		} else {
			curTime += Time.deltaTime;
		}
		rb.velocity = bulletVel * bulletSpeed;
	}

	public void SetVelocity(Vector2 vel) {
		bulletVel = vel;
	}
}
