using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	public float offsetX;
	public float offsetY;

	float trueOffsetX;

	Vector3 offset;

	Rigidbody2D playerRB;

	//Lerp Stuff
	bool lerping = false;
	Vector3 initPos;
	public float LERP_TIME = 0.5f;
	float transTime = 0.0f;

	// Use this for initialization
	void Start () {
		playerRB = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float curVelX = playerRB.velocity.x;
		if (curVelX > 0.1) {
			if (trueOffsetX < offsetX) {
				lerping = true;
				initPos = gameObject.transform.position;
				transTime = 0.0f;
			}
			trueOffsetX = offsetX;
		} else if (StaticMethods.AlmostEquals(curVelX, 0.0f, 0.1f)) {
			if (trueOffsetX != 0) {
				lerping = true;
				initPos = gameObject.transform.position;
				transTime = 0.0f;
			}
			trueOffsetX = 0;
		} else {
			if (trueOffsetX > -offsetX) {
				lerping = true;
				initPos = gameObject.transform.position;
				transTime = 0.0f;
			}
			trueOffsetX = -offsetX;
		}
		offset = new Vector3(trueOffsetX, offsetY, gameObject.transform.position.z - player.transform.position.z);
		if (lerping) {
			PosTimedLerp(player.transform.position + offset);
		} else {
			gameObject.transform.position = player.transform.position + offset;
		}
	}	

	public bool PosTimedLerp(Vector3 finalPos) {

		float timerVal = transTime / LERP_TIME;

		Camera.main.transform.position = Vector3.Lerp(initPos, finalPos, timerVal);

		if (StaticMethods.AlmostEquals(transTime, LERP_TIME, 0.01f)) {
			gameObject.transform.position = finalPos;
			initPos = finalPos;
			transTime = 0.0f;
			lerping = false;
			return true;
		} else {
			transTime += Time.deltaTime;
			return false;
		}
	}
}
