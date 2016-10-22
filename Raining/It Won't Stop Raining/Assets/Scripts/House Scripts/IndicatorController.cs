using UnityEngine;
using System.Collections;

public class IndicatorController : MonoBehaviour {

	public GameObject activateObject;
	public GameObject player;

	public float decayRange;

	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		if (activateObject == null) {
			Debug.LogError("Indicator named " + gameObject.name +  " has null activate object!");
		}
		sprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Activate") && !(activateObject.activeInHierarchy)) {
			activateObject.SetActive(true);
			sprite.enabled = false;
		} else if (Input.GetButtonDown("Activate") && (activateObject.activeInHierarchy)) {
			activateObject.SetActive(false);
			sprite.enabled = true;
		} else if (activateObject.activeInHierarchy && 
			StaticMethods.Distance((Vector2)gameObject.transform.position, (Vector2)player.transform.position) > decayRange) {
			activateObject.SetActive(false);
			sprite.enabled = true;
		}
	}

	void OnDisable() {
		sprite.enabled = true;
		activateObject.SetActive(false);
	}
}
