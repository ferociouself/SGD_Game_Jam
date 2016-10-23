using UnityEngine;
using System.Collections;

public class CareBear : MonoBehaviour {

	float radius;
	float delay,cooldown;
    float damage;

	// Use this for initialization
	void Start () {
		radius = 0.75f;
		delay = 3f;
		cooldown = delay;
        damage = 40f;
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		} else {
			attack ();
		}
	}

	void attack(){
		Collider2D[] enemies = Physics2D.OverlapCircleAll (gameObject.transform.position, radius);
		for (int i = 0; i < enemies.Length; i++) {
			enemies [i].gameObject.GetComponent<EnemyHealth>().takeDamage (damage);
		}
	}
}
