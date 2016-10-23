using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RacingAIController : MonoBehaviour {

	Rigidbody2D rb;

	public float speed;

	public GameObject nodeListObj;
	List<Transform> nodeList;

	bool passedCheckpoint = false;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();

		nodeList = new List<Transform>();

		foreach (Transform obj in nodeListObj.transform) {
			if (obj.CompareTag("Node")) {
				nodeList.Add(obj);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		float curRot = gameObject.transform.rotation.eulerAngles.z;

		Vector2 curOffset = new Vector2(Mathf.Sin(Mathf.Deg2Rad * curRot), -Mathf.Cos(Mathf.Deg2Rad * curRot));

		Vector2 TwoDPos = (Vector2)(gameObject.transform.position);

		Vector2 curDir = TwoDPos - curOffset;

		Vector2 target = new Vector2(0.0f, 0.0f);
		if (nodeList.Count > 0) {
			target = (Vector2)(nodeList[0].position);
		} else {
			Destroy(this);
		}

		float isLeft = StaticMethods.IsLeft(TwoDPos - curDir, TwoDPos - target);
		float onTarget = StaticMethods.IsLeft(TwoDPos - curDir, target - TwoDPos);
		if (StaticMethods.AlmostEquals(onTarget, 0.0f, 0.5f)) {
			rb.AddForce(curOffset * -speed);
			rb.angularVelocity = 0.0f;
		}  else if (isLeft > 0) {
			rb.angularVelocity = speed * 20.0f;
			//rb.velocity = Vector2.zero;
		}  else if (isLeft < 0) {
			rb.angularVelocity = -speed * 20.0f;
			//rb.velocity = Vector2.zero;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.CompareTag("Node")) {
			nodeList.Remove(coll.transform);
		}
		if (coll.gameObject.name == "Halfway Checkpoint") {
			passedCheckpoint = true;
			Debug.Log("AI Passed Checkpoint");
		}
		if (coll.gameObject.name == "Finish Line" && passedCheckpoint) {
			Debug.Log("AI Wins!");
		}
	}




}
