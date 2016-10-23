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
		SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
		switch (type) {
			case InteractableController.ActivateType.TowerDefense:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_ARMYFIGURES)){
					//Do things to start Tower Defense!
				SM.MoveToScene (10, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				}else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.HackAndSlash:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_TOYSWORD)){
					//Do things to start Hack and Slash!
					//Debug.Log("Hack and Slash Started!");
					//SM.MoveToScene (4, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				} else {
					//Tell the player that they need an item.
					//Debug.Log("Need a sword!");
				}
				break;
			case InteractableController.ActivateType.Riddle:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_TOYSWORD)){
					//Do things to start Hack and Slash!
					//Debug.Log("Hack and Slash Started!");
					SM.MoveToScene (9, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				} else {
					//Tell the player that they need an item.
					//Debug.Log("Need a sword!");
				}
			break;
			case InteractableController.ActivateType.HideAndSeek:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_TREAT)){
					//Do things to start Hide and Seek!
					//SM.MoveToScene (4, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				} else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.OperationMaze:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_MASK)){
					//Do things to start Operation: Maze!
					SM.MoveToScene (8, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				}else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.Racing:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_MODELBOAT)){
					//Do things to start Racing!
					SM.MoveToScene (3, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);

				}else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.Rhythm:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_DRUMSTICKS)){
					//Do things to start Rhythm!
					SM.MoveToScene (4, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				}else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.PuzzlePlatformer:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_SHOES)){
					//Do things to start Puzzle Platformer!
					SM.MoveToScene (2, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);

				}else {
					//Tell the player that they need an item.
				}
				break;
			case InteractableController.ActivateType.Asteroids:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_BUGSPRAY)) {
					//START ASTEROIDS
					SM.MoveToScene (7, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				} else {
					// NO START
				}
			break;
			case InteractableController.ActivateType.BrickBreaker:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_BATTERIES)) {
					// START BRICK BREAKER
					SM.MoveToScene (6, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				} else {
					// NO START
				}
			break;
			case InteractableController.ActivateType.DuckHunt:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_SLINGSHOT)) {
					SM.MoveToScene (1, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				} else {
				}
			break;
			case InteractableController.ActivateType.TicTacToe:
				if (playInventory.isInInventory(InteractableController.ActivateType.ITEM_PEN)) {
					SM.MoveToScene (5, player.GetComponent<PlayerInventoryController> ().getInventory(), player.transform.position);
				} else {
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
