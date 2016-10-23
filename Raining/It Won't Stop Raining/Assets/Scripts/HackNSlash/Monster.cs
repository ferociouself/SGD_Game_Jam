using UnityEngine;
using System.Collections;

public class Monster : Mob {

    GameObject playerObj;
    Player player;

    private float attackTimer = 0f;

    override protected void Start()
    {
        base.Start();
        playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Player>();
    }

    override protected void Update () {
        Vector2 dir = player.transform.position - transform.position;
        rigidBody.velocity = dir.normalized * speed;
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (attackTimer <= 0 && collision.gameObject.name == "Player")
            Attack();
    }

    private void Attack()
    {
        player.Hit(damage);
        attackTimer = attackCooldown;
    }

    override protected void Die()
    {
        print("Die: " + name);
        Destroy(gameObject);
    }
}
