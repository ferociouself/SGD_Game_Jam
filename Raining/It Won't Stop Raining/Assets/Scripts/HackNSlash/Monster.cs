using UnityEngine;
using System.Collections;

public class Monster : Mob {

    GameObject playerObj;
    Player player;

    override protected void Start()
    {
        base.Start();
        playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Player>();
    }

    override protected void Update () {
        Vector2 dir = player.transform.position - transform.position;
        rigidBody.velocity = dir.normalized * speed;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
            Attack();
    }

    private void Attack()
    {
        player.Hit(damage);
    }

    override protected void Die()
    {
        print("Die: " + name);
        Destroy(gameObject);
    }
}
