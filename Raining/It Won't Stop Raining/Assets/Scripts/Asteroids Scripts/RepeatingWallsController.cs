using UnityEngine;
using System.Collections;

public class RepeatingWallsController : MonoBehaviour {

	public float teleportYChange = 10.0f;
	public float teleportXChange = 0.0f;

	private Vector2 teleportDelta;

	void Start() {
		teleportDelta = new Vector2(teleportXChange, teleportYChange);
	}

	// Called whenever another object enters the attached object's collider.
	void OnTriggerEnter2D(Collider2D coll) {
		Vector3 currPos = coll.gameObject.transform.position;
		coll.gameObject.transform.position = new Vector2(currPos.x, currPos.y) + teleportDelta;
	}
}
