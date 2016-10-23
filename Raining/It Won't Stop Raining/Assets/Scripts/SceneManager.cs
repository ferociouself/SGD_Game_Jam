﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {

	public static SceneManager s_instance;

	UnityEngine.SceneManagement.SceneManager SM;

	Dictionary<InteractableController.ActivateType, bool> inventory;

	bool waiter;
	float timer;

	/// <summary>
	/// Awaken this instance.
	/// </summary>
	void Awake()
	{
		if (s_instance == null)
		{
			DontDestroyOnLoad(gameObject); // save object on scene mvm
			s_instance = this;
		}
		else if (s_instance != this)
		{
			Destroy(gameObject);
		}
	}

	public Dictionary<InteractableController.ActivateType, bool> getInventory(){
		return inventory;
	}

	void Start() { 
		inventory = new Dictionary<InteractableController.ActivateType, bool>();
		for (int i = InteractableController.ITEM_START - 1; i < InteractableController.ACTIVATE_LENGTH; i++) {
			inventory.Add((InteractableController.ActivateType)i, false);
		}
	}

	void OnEnable(){
		waiter = true;
		timer = 0.00f;
	}

	void Update () {		
		if (waiter && timer >= 2.00f && UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 0) {
			LoadHome ();
			waiter = false;
		} else {
			timer += Time.deltaTime;
		}
	}


	/// <summary>
	/// Moves to scene. Go the the Project Manager to ensure this.
	/// </summary>
	/// <returns><c>true</c>, if to scene was moved, <c>false</c> otherwise.</returns>
	/// <param name="sceneNumber">Scene number.</param>
	public void MoveToScene(int sceneNumber) {
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (sceneNumber);
	}

	public void MoveToScene(int sceneNumber, Dictionary<InteractableController.ActivateType, bool> inv) {
		int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex;

		Debug.Log ("Index: " + index);

		if (index == 0) {
			SaveHome (inv);
			foreach(InteractableController.ActivateType key in inv.Keys){
				//go through all objects in inventory that are active and
				Debug.Log(key.ToString() + " " + inv[key].ToString());
			}

			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (sceneNumber);
		}
	}

	private void SaveHome(Dictionary<InteractableController.ActivateType, bool> inv){
		this.inventory = inv;
	}

	private void LoadHome(){
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 0) {
			if (GameObject.Find ("Jimbo") != null) {
				Debug.Log ("not null jimbo");
				GameObject Player = GameObject.Find ("Jimbo");
				if (Player.GetComponent<PlayerInventoryController> () != null) {
					Debug.Log ("not null inventory");
					Player.GetComponent<PlayerInventoryController> ().setInventory (this.inventory);
				}
			}
		}
	}
}
