using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
    
    Vector2 commonspeed, commondir, move;
    Rigidbody2D rbody;
    Vector2 startvector, endvector;
    GameObject[] colliders;


    /** Some variables about the map- to indicate the path that the enemies should take
     * Enemy center starts at (-3.92, 6.42)
     * First turn- enemy center hits (-3.92, 3.22)
     * Second turn- enemy center hits (2.33, 3.22)
     * Third turn- enemy center hits (2.33, 0.01)
     * Fourth turn- enemy center hits (-2.34, 0.01,)
     * Fifth turn- enemy center hits (-2.34, -3.25)
     * Sixth turn- enemy center hits (3.91, -3.25)
     * HP loss when enemy center hits (3.91, -6.4)
     **/


    // Use this for initialization
    void Start()
    {
        commonspeed = new Vector2(.5F, .5F);
        commondir = new Vector2(0, -1);
        move = new Vector2(commonspeed.x * commondir.x, commonspeed.y * commondir.y);
        startvector = new Vector2(-4F, 6.5F);
        gameObject.transform.position = startvector;
        colliders = new GameObject[6];
        
        //turnvectors = new Vector2[6];
        //turnvectors[0] = new Vector2(-3.92F, 3.22F);
        //turnvectors[1] = new Vector2(2.33F, 3.22F);
        //turnvectors[2] = new Vector2(2.33F, 0.01F);
        //turnvectors[3] = new Vector2(-2.34F, 0.01F);
        //turnvectors[4] = new Vector2(-2.34F, -3.25F);
        //turnvectors[5] = new Vector2(3.91F, -3.25F);
        endvector = new Vector2(3.9F, -6.3F);
    }

    void onCollisionEnter (Collider2D other)
    {
        if (other.gameObject.name == "turn1")
        {
            commondir.x = 1;
            commondir.y = 0;
        }
    }




    // Update is called once per frame
    void Update()
    {
        move.x = commonspeed.x * commondir.x;
        move.y = commonspeed.y * commondir.y;
        float constant = 3.25f;
        //Try 4- let's not do collision detection or points at all! We know the enemy's gonna go at this speed, so let's just make sure he goes these directions at these times.
        //And it fuckin works bro
        if (Time.time > 2*constant && Time.time < 6*constant)
        {
            commondir.x = 1;
            commondir.y = 0;
        }
        if (Time.time > 6*constant && Time.time < 8*constant)
        {
            commondir.x = 0;
            commondir.y = -1;
        }
        if (Time.time > 8*constant && Time.time < 11*constant)
        {
            commondir.x = -1;
            commondir.y = 0;
        }
        if (Time.time > 11*constant && Time.time < 13*constant)
        {
            commondir.x = 0;
            commondir.y = -1;
        }
        if (Time.time > 13*constant && Time.time < 14*constant)
        {
            commondir.x = 1;
            commondir.y = 0;
        }
        if (Time.time > 17*constant && Time.time < 19*constant)
        {
            commondir.x = 0;
            commondir.y = -1;
        }
        if (Time.time > 19*constant)
        {
            commondir.x = -1;
            commondir.y = 1;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);

        //float error = .2f;
        ////Try 3
        //if(gameObject.transform.position.y - colliders[0].transform.position.y  <= error)
        //{
        //    commondir.x = 1;
        //    commondir.y = 0;
        //}

        ////Try 2- either changed direction all the time or was 
        ////set at commondir = (1, -1)
        //int counter = 0;
        //if (counter == 0)
        //{
        //    if (gameObject.transform.position.y <=  turnvectors[0].y)
        //    {
        //        commondir.x = 1;
        //        commondir.y = 0;
        //        counter++;
        //    }
        //}
        //if (counter == 1)
        //{
        //    if (gameObject.transform.position.x >= turnvectors[1].x)
        //    {
        //        commondir.x = 0;
        //        commondir.y = -1;
        //        counter++;
        //    }
        //}
        //if (counter == 2)
        //{
        //    if (gameObject.transform.position.y <= turnvectors[2].y)
        //    {
        //        commondir.x = -1;
        //        commondir.y = 0;
        //        counter++;
        //    }
        //}
        //if (counter == 3)
        //{
        //    if (gameObject.transform.position.x <= turnvectors[3].x)
        //    {
        //        commondir.x = 0;
        //        commondir.y = -1;
        //        counter++;
        //    }
        //}
        //if (counter == 4)
        //{
        //    if (gameObject.transform.position.y <= turnvectors[4].y)
        //    {
        //        commondir.x = 1;
        //        commondir.y = 0;
        //        counter++;
        //    }
        //}
        //if (counter == 5)
        //{
        //    if (gameObject.transform.position.x >= turnvectors[5].x)
        //    {
        //        commondir.x = 0;
        //        commondir.y = -1;
        //        counter++;
        //    }
        //}

        ////Try 1- didn't change direction at all
        //for (int i = 0; i < turnvectors.Length; i++)
        //{
        //    if (gameObject.transform.position == turnvectors[i])
        //    {
        //        if (i % 2 == 0)
        //        {
        //            commondir.x = 0;
        //            commondir.y = -1;
        //        }
        //        else if (i == 3)
        //        {
        //            commondir.x = -1;
        //            commondir.y = 0;
        //        }
        //        else
        //        {
        //            commondir.x = 1;
        //            commondir.y = 0;
        //        }
        //    }


    }

    void FixedUpdate()
    {
        if (rbody == null) rbody = GetComponent<Rigidbody2D>();

        rbody.velocity = move;
    }
}
