using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    enum Direction
    {
        Up, Down, Left, Right
    }

    private const KeyCode UPKEY = KeyCode.W;
    private const KeyCode DOWNKEY = KeyCode.S;
    private const KeyCode LEFTKEY = KeyCode.A;
    private const KeyCode RIGHTKEY = KeyCode.D;
    private const KeyCode ATTACKKEY = KeyCode.J;

    public float speed;
    public float swordRange;
    public Sprite upSprite, downSprite, leftSprite, rightSprite;

    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;

    Direction direction;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
        Vector2 velocity = Vector2.zero;
        if (Input.GetKey(UPKEY))
        {
            velocity.y = 1;
            direction = Direction.Up;
            spriteRenderer.sprite = upSprite;
        }
        else if (Input.GetKey(DOWNKEY))
        {
            velocity.y = -1;
            direction = Direction.Down;
            spriteRenderer.sprite = downSprite;
        }
        if (Input.GetKey(LEFTKEY))
        {
            velocity.x = -1;
            direction = Direction.Left;
            spriteRenderer.sprite = leftSprite;
        }
        else if (Input.GetKey(RIGHTKEY))
        {
            velocity.x = 1;
            direction = Direction.Right;
            spriteRenderer.sprite = rightSprite;
        }
        rigidBody.velocity = velocity.normalized * speed;


        if (Input.GetKey(ATTACKKEY))
        {
            print("attack");
            Vector2 pointA = new Vector2();
            Vector2 pointB = new Vector2();
            float x = transform.position.x;
            float y = transform.position.y;
            switch (direction)
            {
                case Direction.Up:
                    pointA = new Vector2(x - swordRange, y - swordRange);
                    pointB = new Vector2(x + 2 * swordRange, y + swordRange);
                    break;
                case Direction.Down:
                    pointA = new Vector2(x - swordRange, y);
                    pointB = new Vector2(x + 2*swordRange, y + swordRange);
                    break;
                case Direction.Left:
                    pointA = new Vector2(x - swordRange, y - swordRange);
                    pointB = new Vector2(x + swordRange, y + 2 * swordRange);
                    break;
                case Direction.Right:
                    pointA = new Vector2(x, y - swordRange);
                    pointB = new Vector2(x + swordRange, y + 2 * swordRange);
                    break;
            }
            Collider2D[] collisions = Physics2D.OverlapAreaAll(pointA, pointB, 1 << 8);
        }
    }
}
