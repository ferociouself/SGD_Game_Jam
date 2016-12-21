using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

	public enum AsteroidSize {
		Tiny,
		Small,
		Medium,
		Big,
		Huge,
		Yuge
	}

	public AudioSource hitSound;

	public AsteroidSize size;

	Rigidbody2D rb;

	public Vector2 dir;
	public float speed;

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3((float)(size + 1), (float)(size + 1), 1.0f);
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = dir * speed;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag("Projectile")) {
			hitSound.Play ();
			Destroy(coll.gameObject);
			if (size == AsteroidSize.Tiny) {
				Destroy(gameObject);
			} else {
				Split();
				Destroy(gameObject);
			}
		}
	}

	void Split() {
		GameObject ast1 = (GameObject)(Resources.Load("Prefabs/Asteroids/Asteroid", typeof(GameObject)));
		GameObject ast2 = (GameObject)(Resources.Load("Prefabs/Asteroids/Asteroid", typeof(GameObject)));

		GameObject instAst1 = GameObject.Instantiate(ast1);
		GameObject instAst2 = GameObject.Instantiate(ast2);

		AsteroidController ast1Cont = instAst1.GetComponent<AsteroidController>();
		AsteroidController ast2Cont = instAst2.GetComponent<AsteroidController>();

		ast1Cont.size = (AsteroidSize)(this.size - 1);
		ast2Cont.size = (AsteroidSize)(this.size - 1);

		ast1Cont.dir = new Vector2(Random.Range(-1.0f, -0.1f), Random.Range(-1.0f, 1.0f));
		ast2Cont.dir = new Vector2(Random.Range(0.1f, 1.0f), Random.Range(-1.0f, 1.0f));

		ast1Cont.speed = this.speed * 1.1f;
		ast2Cont.speed = this.speed * 1.1f;

		instAst1.transform.position = gameObject.transform.position + (Vector3)ast1Cont.dir;
		instAst2.transform.position = gameObject.transform.position + (Vector3)ast2Cont.dir;
	}
}
