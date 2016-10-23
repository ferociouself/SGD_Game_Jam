using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

    protected enum Direction
    {
        Down, Up, Left, Right
    }

    public int health;
    public int damage;
    public float speed;

    [HideInInspector]
    public Vector2 velocity = new Vector2();
    //protected Direction direction = Direction.Down;
    //protected bool walking = false;

    protected Rigidbody2D rigidBody;
    protected Animator animator;

    // Use this for initialization
    protected virtual void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update () {
	
	}

    public virtual void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {

    }

}
