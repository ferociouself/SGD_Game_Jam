using UnityEngine;
using System.Collections;

public class ActivateController : MonoBehaviour {

	public GameObject player;

	public GameObject interactableObject;

	public InteractableController.ActivateType type;
	PlayerInventoryController playInventory;

	public float decayRange;

	void Start() {
		playInventory = player.GetComponent<PlayerInventoryController>();
	}

	// Update is called once per frame
	void Update () {
		if (StaticMethods.Distance((Vector2)interactableObject.transform.position, (Vector2)player.transform.position) > decayRange) {
			gameObject.SetActive(false);
		}
		if (Input.GetButtonDown("Activate")) {
			gameObject.SetActive(false);
			Activate();
		} else if (Input.GetButtonDown("Deactivate")) {
			gameObject.SetActive(false);
		}
	}

	void Activate() {
		if (type == InteractableController.ActivateType.TestGame) {
			//Switch to that game.
		}
		if (type == InteractableController.ActivateType.ITEM_HAMMER) {
			Debug.Log("Interactable is Hammer! Interacted!");
			playInventory.setInventoryActive(type);
		}
	}
}
