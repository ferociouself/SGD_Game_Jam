using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    float health;
	// Use this for initialization
	void Start () {
        health = 100;
	}
    
    public void takeDamage(float damage)
    {
        health -= damage;
    }

    void checkDead()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
        checkDead();
	}
}
