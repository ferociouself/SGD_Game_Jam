using UnityEngine;
using System.Collections;

public class LavaChecker : MonoBehaviour
{

	bool playerDied;
	float restartDelay;

	// Use this for initialization
	void Start ()
	{
		restartDelay = 0;
		playerDied = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerDied) {
			if (restartDelay < 0) {
				UnityEngine.SceneManagement.SceneManager.LoadScene("Platforming");
			} else {
				restartDelay -= Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			playerDied = true;
			restartDelay = 1;
		}
	}
}

