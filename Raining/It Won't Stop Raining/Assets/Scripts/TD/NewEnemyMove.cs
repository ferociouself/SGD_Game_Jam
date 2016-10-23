using UnityEngine;
using System.Collections;

public class NewEnemyMove : MonoBehaviour {
    GameObject enemy;
    int counter;
    Collider2D[] collisionBoxes;
    Vector2[] directions;
    Vector2 speed;
    Vector2 movement;
    Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
        counter = 0;
        collisionBoxes = new Collider2D[6];
        enemy = new GameObject();
        directions = new Vector2[4];
        directions[0] = new Vector2(0, 1);
        directions[1] = new Vector2(1, 0);
        directions[2] = new Vector2(0, -1);
        directions[3] = new Vector2(-1, 0);
        speed = new Vector2(.5f, .5f);
        movement = new Vector2(speed.x * directions[2].x, speed.y * directions[2].y);
	}

    
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider2D collider)
    {
       
                if (counter == 1 || counter ==3 || counter == 5)
                {
                    movement = new Vector2(directions[2].x * speed.x, directions[2].y * speed.y);
                }
                else if (counter == 0 || counter == 4)
                {
                    movement = new Vector2(directions[1].x * speed.x, directions[1].y * speed.y);
                }
                else if (counter == 2)
                {
                    movement = new Vector2(directions[3].x * speed.x, directions[3].y * speed.y);
                }
        counter++;
    }

    // Update is called once per frame
    void Update ()
    {
        if (rbody.velocity.x == 0f && rbody.velocity.y == 0f)
        {
            if (counter == 1 || counter == 3 || counter == 5)
            {
                movement = new Vector2(directions[2].x * speed.x, directions[2].y * speed.y);
            }
            else if (counter == 0 || counter == 4)
            {
                movement = new Vector2(directions[1].x * speed.x, directions[1].y * speed.y);
            }
            else if (counter == 2)
            {
                movement = new Vector2(directions[3].x * speed.x, directions[3].y * speed.y);
            }
            counter++;
        }

    }

    void FixedUpdate()
    {
        if (rbody == null) rbody = GetComponent<Rigidbody2D>();

        rbody.velocity = movement;
    }
}
