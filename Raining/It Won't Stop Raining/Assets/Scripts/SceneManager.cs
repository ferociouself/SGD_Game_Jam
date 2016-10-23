using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public static SceneManager s_instance;

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

	void Update () { }


	/// <summary>
	/// Moves to scene. Go the the Project Manager to ensure this.
	/// </summary>
	/// <returns><c>true</c>, if to scene was moved, <c>false</c> otherwise.</returns>
	/// <param name="sceneNumber">Scene number.</param>
	public void MoveToScene(int sceneNumber) {
		Application.LoadLevel (sceneNumber);
	}
}
