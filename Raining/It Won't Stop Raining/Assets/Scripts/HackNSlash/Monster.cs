using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    public float speed;

    Rigidbody2D rigidBody;
    Player player;

	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
	
	void Update () {
        Vector2 dir = player.transform.position - transform.position;
        rigidBody.velocity = dir.normalized * speed;
	}
}
