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

    protected Direction direction = Direction.Down;
    protected bool walking = false;

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

    public void Hit(int damage)
    {
        print("Hit: " + name + ": " + damage);
        health -= damage;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {

    }

}
