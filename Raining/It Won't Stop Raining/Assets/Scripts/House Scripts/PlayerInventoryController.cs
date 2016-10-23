using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventoryController : MonoBehaviour {

	Dictionary<InteractableController.ActivateType, bool> inventory;

	public GameObject inventoryUIController;

	InventoryUIController ui;

	float timer;


	// Use this for initialization
	void Start () {
		inventory = new Dictionary<InteractableController.ActivateType, bool>();
		for (int i = InteractableController.ITEM_START - 1; i < InteractableController.ACTIVATE_LENGTH; i++) {
			inventory.Add((InteractableController.ActivateType)i, false);
		}
		ui = inventoryUIController.GetComponent<InventoryUIController>();

		timer = 0.00f;
	}

	public void setInventory(Dictionary<InteractableController.ActivateType, bool> inv){
		this.inventory = inv;
		foreach(InteractableController.ActivateType key in this.inventory.Keys){
			//go through all objects in inventory that are active and
			//activate them
			if (inventory [key]) {
				ui.ActivateIcon (key);
			}
		}
	}

	public Dictionary<InteractableController.ActivateType, bool> getInventory(){
		return this.inventory;
	}
	
	// Update is called once per frame
	void Update () {

		if (timer > 2.00f && timer < 5.00f) {
			SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager> ();
			setInventory(SM.getInventory ());
		} 

		if (timer < 10.00f){
			timer += Time.deltaTime;
		} 
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
