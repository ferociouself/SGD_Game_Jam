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
		GameObject ast1;
		GameObject ast2;

		ast1 = (GameObject)(Resources.Load("Prefabs/Asteroids/Asteroid", typeof(GameObject)));
		ast2 = (GameObject)(Resources.Load("Prefabs/Asteroids/Asteroid", typeof(GameObject)));

		AsteroidController ast1Cont = ast1.GetComponent<AsteroidController>();
		AsteroidController ast2Cont = ast2.GetComponent<AsteroidController>();

		ast1Cont.size = (AsteroidSize)(this.size - 1);
		ast2Cont.size = (AsteroidSize)(this.size - 1);

		ast1Cont.dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
		Debug.Log(ast1Cont.dir);
		ast2Cont.dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
		Debug.Log(ast2Cont.dir);

		ast1Cont.speed = this.speed * 1.1f;
		ast2Cont.speed = this.speed * 1.1f;

		ast1.transform.position = gameObject.transform.position;
		ast2.transform.position = gameObject.transform.position;



		GameObject instAst1;
		GameObject instAst2;

		instAst1 = GameObject.Instantiate(ast1);
		instAst2 = GameObject.Instantiate(ast2);
	}
}
