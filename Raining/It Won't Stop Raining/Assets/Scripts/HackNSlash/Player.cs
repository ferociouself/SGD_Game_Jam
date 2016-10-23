﻿using UnityEngine;
using System.Collections;

public class Player : Mob {

    private const KeyCode UPKEY = KeyCode.W;
    private const KeyCode DOWNKEY = KeyCode.S;
    private const KeyCode LEFTKEY = KeyCode.A;
    private const KeyCode RIGHTKEY = KeyCode.D;
    private const KeyCode ATTACKKEY = KeyCode.J;

    public float swordRange;

    private float attackTimer = 0f;
    private SpriteRenderer spriteRenderer;

    override protected void Start () {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	override protected void Update () {
        Vector2 velocity = Vector2.zero;
        walking = false;
        if (attackTimer <= 0)
        {
            if (Input.GetKey(UPKEY))
            {
                velocity.y = 1;
                direction = Direction.Up;
                walking = true;
            }
            else if (Input.GetKey(DOWNKEY))
            {
                velocity.y = -1;
                direction = Direction.Down;
                walking = true;
            }
            if (Input.GetKey(LEFTKEY))
            {
                velocity.x = -1;
                direction = Direction.Left;
                walking = true;
            }
            else if (Input.GetKey(RIGHTKEY))
            {
                velocity.x = 1;
                direction = Direction.Right;
                walking = true;
            }
        }
        rigidBody.velocity = velocity.normalized * speed;
        spriteRenderer.flipX = direction == Direction.Left;
        animator.SetBool("Walking", walking);
        animator.SetInteger("Direction", (int)direction);

        if (attackTimer <= 0 && Input.GetKeyDown(ATTACKKEY))
        {
            Attack();
        }

        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
    }

    private void Attack()
    {
        print("Attack: " + name);
        animator.SetTrigger("Attack");
        attackTimer = attackCooldown;
        //canMove = false;
        Vector2 center, size;
        GetAttackRect(out center, out size);
        Collider2D[] collisions = Physics2D.OverlapBoxAll(center, size, 0f, LayerMask.GetMask("Monsters"));
        foreach (Collider2D collision in collisions)
        {
            GameObject monsterObj = collision.gameObject;
            Monster monster = monsterObj.GetComponent<Monster>();
            monster.Hit(damage);
        }
    }

    //public void AttackEnd()
    //{
    //    canMove = true;
    //}

    private void GetAttackRect(out Vector2 center, out Vector2 size)
    {
        center = new Vector2();
        size = new Vector2();
        float x = transform.position.x;
        float y = transform.position.y;
        switch (direction)
        {
            case Direction.Down:
                center = new Vector2(x, y - swordRange / 4);
                size = new Vector2(swordRange, swordRange / 2);
                break;
            case Direction.Up:
                center = new Vector2(x, y + swordRange / 4);
                size = new Vector2(swordRange, swordRange / 2);
                break;
            case Direction.Left:
                center = new Vector2(x - swordRange / 4, y);
                size = new Vector2(swordRange / 2, swordRange);
                break;
            case Direction.Right:
                center = new Vector2(x + swordRange / 4, y);
                size = new Vector2(swordRange / 2, swordRange);
                break;
        }
    }

    override protected void Die()
    {
        print("Player died!!1");
    }

    void OnDrawGizmos()
    {
        Vector2 center, size;
        GetAttackRect(out center, out size);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }
}
