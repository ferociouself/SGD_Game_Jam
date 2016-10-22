using UnityEngine;
using System.Collections;

public class IndicatorController : MonoBehaviour {

	public GameObject activateObject;
	public GameObject player;

	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		if (activateObject == null) {
			Debug.LogError("Indicator named " + gameObject.name +  " has null activate object!");
		}
		sprite = gameObject.GetComponent<SpriteRenderer>();
		activateObject.GetComponent<ActivateController>().player = player;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Activate") && !(activateObject.activeInHierarchy)) {
			activateObject.SetActive(true);
		}
		if (activateObject.activeInHierarchy) {
			sprite.enabled = false;
		} else {
			sprite.enabled = true;
		}
	}
}
