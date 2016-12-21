using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    float cooldown;
    public GameObject enemy;
    Vector2 position;
    Quaternion rotation;
	// Use this for initialization
	void Start ()
    {
        cooldown = 7f;
        
        rotation = new Quaternion(0, 0, 0, 0);
        position = new Vector2(281.04f, 195.87f);
	}
	
    void spawn()
    {
        GameObject.Instantiate(enemy, position, rotation);
        enemy.GetComponent<EnemyHealth>();
        cooldown = 7f;
    }

	// Update is called once per frame
	void Update () {
	    if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            spawn();
        }
	}
}
