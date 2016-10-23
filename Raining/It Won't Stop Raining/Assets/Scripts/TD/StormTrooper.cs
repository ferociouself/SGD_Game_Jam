using UnityEngine;
using System.Collections;

public class StormTrooper : MonoBehaviour
{
    float radius;
    float delay, cooldown;
    float damage;

	// Use this for initialization
	void Start ()
    {
        radius = 1.5f;
        delay = 1f;
        cooldown = delay;
        damage = 20f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            attack();
        }
	
	}

    void attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);
        int guy = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            int dist = 10000000;
            if (i == 0)
            {
                dist = (int) Mathf.Sqrt(((gameObject.transform.position.x - enemies[i].gameObject.transform.position.x)*
                    (gameObject.transform.position.x - enemies[i].gameObject.transform.position.x)) +
                    ((gameObject.transform.position.y - enemies[i].gameObject.transform.position.y)*
                    (gameObject.transform.position.y - enemies[i].gameObject.transform.position.y)))
                    ;
                    //gameObject.transform.position - enemies[i].gameObject.transform.position;
            }
            if (i > 0)
            {
                int check = (int) Mathf.Sqrt(((gameObject.transform.position.x - enemies[i].gameObject.transform.position.x) *
                    (gameObject.transform.position.x - enemies[i].gameObject.transform.position.x)) +
                    ((gameObject.transform.position.y - enemies[i].gameObject.transform.position.y) *
                    (gameObject.transform.position.y - enemies[i].gameObject.transform.position.y)))
                    ;
                    //gameObject.transform.position - enemies[i].gameObject.transform.position;
                if (check <= dist)
                {
                    dist = check;
                    guy = i;
                }
            }
        }
        if (guy >= 0 && guy < enemies.Length)
        {
            enemies[guy].gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
        }
    }
}
