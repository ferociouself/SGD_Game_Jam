using UnityEngine;
using System.Collections;

public class InteractableController : MonoBehaviour {

	public GameObject indicator;
	public GameObject player;

	ActivateController activator;

	public float range;

	public enum ActivateType {
		TestGame,
		TestGame2,
		TestGame3,
		ITEM_HAMMER
	};

	public const int ITEM_START = 3;
	public const int ACTIVATE_LENGTH = 4;

	public ActivateType type;

	// Use this for initialization
	void Awake () {
		indicator.GetComponent<IndicatorController>().player = player;
		activator = indicator.GetComponent<IndicatorController>().activateObject.GetComponent<ActivateController>();
		activator.type = type;
		activator.interactableObject = gameObject;
		activator.player = player;
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
