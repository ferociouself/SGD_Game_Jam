using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventoryController : MonoBehaviour {

	Dictionary<InteractableController.ActivateType, bool> inventory;

	public GameObject inventoryUIController;

	InventoryUIController ui;


	// Use this for initialization
	void Start () {
		inventory = new Dictionary<InteractableController.ActivateType, bool>();
		for (int i = InteractableController.ITEM_START; i < InteractableController.ACTIVATE_LENGTH; i++) {
			inventory.Add((InteractableController.ActivateType)i, false);
		}
		ui = inventoryUIController.GetComponent<InventoryUIController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool setInventoryActive(InteractableController.ActivateType item) {
		if ((int)item < InteractableController.ITEM_START || (int)item > InteractableController.ACTIVATE_LENGTH) {
			return false;
		}
		inventory[item] = true;
		ui.ActivateIcon(item);
		return inventory[item];
	}

	public bool setInventoryDeactive(InteractableController.ActivateType item) {
		if ((int)item < InteractableController.ITEM_START || (int)item > InteractableController.ACTIVATE_LENGTH) {
			return false;
		}
		inventory[item] = false;
		ui.ActivateIcon(item);
		return !inventory[item];
	}

	public bool isInInventory(InteractableController.ActivateType item) {
		return inventory[item];
	}
}
