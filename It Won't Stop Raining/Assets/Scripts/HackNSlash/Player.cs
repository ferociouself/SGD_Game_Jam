using UnityEngine;
using System.Collections;

public class Player : Mob {

    //private const KeyCode UPKEY = KeyCode.W;
    //private const KeyCode DOWNKEY = KeyCode.S;
    //private const KeyCode LEFTKEY = KeyCode.A;
    //private const KeyCode RIGHTKEY = KeyCode.D;
    private const KeyCode ATTACKKEY = KeyCode.J;

    public float swordRange = 0.5f;
    public float attackCooldown = 0.3f;
    public float damageCooldown = 1f;

    private float attackTimer = 0f;
    private float damageTimer = 0f;

    private SpriteRenderer spriteRenderer;

    override protected void Start () {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	override protected void Update () {
        if (attackTimer == 0)
        {
            //float x = 0;
            //float y = 0;
            //if (Input.GetKey(DOWNKEY)) y = -1;
            //else if (Input.GetKey(UPKEY)) y = 1;
            //if (Input.GetKey(LEFTKEY)) x = -1;
            //else if (Input.GetKey(RIGHTKEY)) x = 1;
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            //print(x + ", " + y);
            rigidBody.velocity = velocity = new Vector2(x, y).normalized * speed;
        }

        if (attackTimer == 0)
        {
            if (Input.GetKeyDown(ATTACKKEY))
                Attack();
        }
        else
        {
            attackTimer = Mathf.Max(attackTimer - Time.deltaTime, 0);
        }

        if (damageTimer > 0)
        {
            damageTimer = Mathf.Max(damageTimer - Time.deltaTime, 0);
            spriteRenderer.color = Color.gray;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    private void Attack()
    {
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
        Direction direction = (Direction)animator.GetInteger("Direction");
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

    public override void Hit(int damage)
    {
        if (damageTimer <= 0)
        {
            //print("Hit!");
            base.Hit(damage);
            damageTimer = damageCooldown;
        }
    }

    override protected void Die()
    {
        print("Player died!!1");
		SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
		SM.MoveToScene (0);
    }

    void OnDrawGizmos()
    {
        animator = GetComponent<Animator>();
        Vector2 center, size;
        GetAttackRect(out center, out size);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }
}
