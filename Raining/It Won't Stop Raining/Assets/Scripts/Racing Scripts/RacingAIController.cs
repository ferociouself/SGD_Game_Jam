using UnityEngine;
using System.Collections;

public class RacingAIController : MonoBehaviour {

	Rigidbody2D rb;

	public float speed;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float isLeft = StaticMethods.IsLeft(TwoDPos - curDir, TwoDPos - target);
		float onTarget = StaticMethods.IsLeft(TwoDPos - curDir, target - TwoDPos);
		if (StaticMethods.AlmostEquals(onTarget, 0.0f, 0.5f)) {
			rb.AddForce(force * -speed);
			rb.angularVelocity = 0.0f;
		}  else if (isLeft > 0) {
			rb.angularVelocity = speed;
			//rb.velocity = Vector2.zero;
		}  else if (isLeft < 0) {
			rb.angularVelocity = -speed;
			//rb.velocity = Vector2.zero;
		}
	}

	curRot = gameObject.transform.rotation.eulerAngles.z;

	curOffset = new Vector2(Mathf.Sin(Mathf.Deg2Rad * curRot), -Mathf.Cos(Mathf.Deg2Rad * curRot));

	curDir = StaticMethods.V3TOV2(gameObject.transform.position) + curOffset;

	TwoDPos = StaticMethods.V3TOV2(gameObject.transform.position);


}
