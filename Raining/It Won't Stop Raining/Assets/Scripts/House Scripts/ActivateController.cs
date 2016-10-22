using UnityEngine;
using System.Collections;

public class ActivateController : MonoBehaviour {

	public GameObject player;

	public float decayRange;
	
	// Update is called once per frame
	void Update () {
		if (StaticMethods.Distance((Vector2)gameObject.transform.position, (Vector2)player.transform.position) > decayRange) {
			gameObject.SetActive(false);
		}
		if (Input.GetButtonDown("Activate")) {
			gameObject.SetActive(false);
		}
	}
}
