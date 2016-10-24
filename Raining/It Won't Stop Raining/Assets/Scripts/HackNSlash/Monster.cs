using UnityEngine;
using System.Collections;

public class Monster : Mob {

    GameObject playerObj;
    Player player;
    GameController gameCont;

    private float attackTimer = 0f;

    override protected void Start()
    {
        base.Start();
        playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        gameCont = GameObject.Find("GameController").GetComponent<GameController>();
    }

    override protected void Update () {
        Vector2 dir = player.transform.position - transform.position;
        rigidBody.velocity = velocity = dir.normalized * speed;
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")// && attackTimer <= 0)
            Attack();
    }

    private void Attack()
    {
        //print("Attack!");
        player.Hit(damage);
        //attackTimer = attackCooldown;
    }

    override protected void Die()
    {
        Destroy(gameObject);
        gameCont.monstersLeft--;
    }
}
