using UnityEngine;
using System.Collections;

public class InteractableController : MonoBehaviour {

	public GameObject indicator;
	public GameObject player;

	public float range;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//memes
		if (StaticMethods.Distance((Vector2)gameObject.transform.position, (Vector2)player.transform.position) < range) {
			indicator.SetActive(true);
		} else if (indicator.activeInHierarchy) {
			indicator.SetActive(false);
		}
	}
}
