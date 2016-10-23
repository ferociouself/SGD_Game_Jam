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
		switch (type) {
			case InteractableController.ActivateType.TowerDefense:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_ARMYFIGURES)){
					//Do things to start Tower Defense!
				}else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.HackAndSlash:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_TOYSWORD)){
					//Do things to start Hack and Slash!
					Debug.Log("Hack and Slash Started!");
					SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
					Debug.Log(SM);
					SM.MoveToScene (4, player.GetComponent<PlayerInventoryController> ().getInventory());
				}else {
					//Tell the player that they need an item.
					Debug.Log("Need a sword!");
				}
				break;
			case InteractableController.ActivateType.HideAndSeek:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_TREAT)){
					//Do things to start Hide and Seek!
					
				} else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.OperationMaze:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_LASERPOINTER)){
					//Do things to start Operation: Maze!
				}else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.Racing:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_MODELBOAT)){
					//Do things to start Racing!
				}else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.Rhythm:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_DRUMSTICKS)){
					//Do things to start Rhythm!
				}else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.PuzzlePlatformer:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_SHOES)){
					//Do things to start Puzzle Platformer!
				}else {
					//Tell the player that they need an item.
				}
				break;
			default:
				if ((int)type > InteractableController.ITEM_START - 1) {
					playInventory.setInventoryActive(type);
					Debug.Log(interactableObject);
					interactableObject.SetActive(false);
				}
				break;
		}
	}
}
