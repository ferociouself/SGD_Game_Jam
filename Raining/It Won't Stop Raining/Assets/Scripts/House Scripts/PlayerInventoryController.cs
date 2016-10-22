using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventoryController : MonoBehaviour {

	Dictionary<InteractableController.ActivateType, bool> inventory;


	// Use this for initialization
	void Start () {
		inventory = new Dictionary<InteractableController.ActivateType, bool>();
		for (int i = InteractableController.ITEM_START; i < InteractableController.ACTIVATE_LENGTH; i++) {
			inventory.Add((InteractableController.ActivateType)i, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool setInventoryActive(InteractableController.ActivateType item) {
		if ((int)item < InteractableController.ITEM_START || (int)item > InteractableController.ACTIVATE_LENGTH) {
			return false;
		}
		inventory[item] = true;
		return inventory[item];
	}
}
