using UnityEngine;
using System.Collections;

public class AsteroidsPlayerController : MonoBehaviour {

	public float speed;

	Rigidbody2D rb;

	public Vector2 bulletOffset;

	public float turnSpeed;

	public AudioSource shootSound;

	float curRot;
	Vector2 force;

	bool won = false;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		curRot = gameObject.transform.rotation.eulerAngles.z;

		force = new Vector2(Mathf.Sin(Mathf.Deg2Rad * curRot), -Mathf.Cos(Mathf.Deg2Rad * curRot));

		rb.velocity = Input.GetAxis("Vertical") * force * -speed;

		if (Input.GetButton("Right")) {
			rb.angularVelocity = -speed * turnSpeed;
		}
		else if (Input.GetButton("Left")) {
			rb.angularVelocity = speed * turnSpeed;
		} else {
			rb.angularVelocity = 0.0f;
		}

		if (Input.GetButtonDown("Activate")) {
			FireProjectile();
		}

		if (GameObject.FindGameObjectsWithTag("Asteroid").Length == 0 && !won) {
			Debug.Log("You win!");
			won = true;
			// End Game
		}

	}

	void FireProjectile() {
		GameObject bullet1;

		Vector3 bulletOffset1 = (Vector3)(new Vector2(bulletOffset.x, bulletOffset.y));

		bullet1 = (GameObject)(Resources.Load("Prefabs/Asteroids/Bullet", typeof(GameObject)));

		bullet1.transform.position = gameObject.transform.position + bulletOffset1;

		GameObject instBullet1 = GameObject.Instantiate(bullet1);

		instBullet1.GetComponent<BulletController>().SetVelocity(-force);

		shootSound.Play ();
	}
}
