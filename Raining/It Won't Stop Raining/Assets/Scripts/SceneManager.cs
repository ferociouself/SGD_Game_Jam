using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {

	public static SceneManager s_instance;

	UnityEngine.SceneManagement.SceneManager SM;

	Dictionary<InteractableController.ActivateType, bool> inventory;
	bool firstTime = true;

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

	void OnEnable(){
		if (!firstTime) {
			if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 0) {
				if (GameObject.Find ("Jimbo") != null) {
					GameObject Player = GameObject.Find ("Jimbo");
					if (Player.GetComponent<PlayerInventoryController> () != null) {
						Debug.Log ("You shouldn't be here, Harry.");
						Player.GetComponent<PlayerInventoryController> ().setInventory (this.inventory);
					}
				}
			}
		}
		firstTime = false;
	}

	void Update () { }


	/// <summary>
	/// Moves to scene. Go the the Project Manager to ensure this.
	/// </summary>
	/// <returns><c>true</c>, if to scene was moved, <c>false</c> otherwise.</returns>
	/// <param name="sceneNumber">Scene number.</param>
	public void MoveToScene(int sceneNumber) {
		int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex;

		if (index != 0) {
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (sceneNumber);
		}
	}

	public void MoveToScene(int sceneNumber, Dictionary<InteractableController.ActivateType, bool> inv) {
		int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex;

		if (index == 0) {
			SaveHome (inv);
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (sceneNumber);
		}
	}

	private void SaveHome(Dictionary<InteractableController.ActivateType, bool> inv){
		this.inventory = inv;
	}
}
