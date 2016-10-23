using UnityEngine;
using System.Collections;

public class Player : Mob {

    private const KeyCode UPKEY = KeyCode.W;
    private const KeyCode DOWNKEY = KeyCode.S;
    private const KeyCode LEFTKEY = KeyCode.A;
    private const KeyCode RIGHTKEY = KeyCode.D;
    private const KeyCode ATTACKKEY = KeyCode.J;

    public float swordRange;

    SpriteRenderer spriteRenderer;

    override protected void Start () {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	override protected void Update () {
        Vector2 velocity = Vector2.zero;
        if (Input.GetKey(UPKEY))
        {
            velocity.y = 1;
			direction = Direction.Up;
        }
        else if (Input.GetKey(DOWNKEY))
        {
			velocity.y = -1;
			direction = Direction.Down;
        }
        if (Input.GetKey(LEFTKEY))
        {
			velocity.x = -1;
			direction = Direction.Left;
        }
        else if (Input.GetKey(RIGHTKEY))
        {
			velocity.x = 1;
			direction = Direction.Right;
        }
        rigidBody.velocity = velocity.normalized * speed;

        if (Input.GetKeyDown(ATTACKKEY))
        {
            Attack();
        }
    }

    private void Attack()
    {
        print("Attack: " + name);
        animator.SetTrigger("Attack");
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
