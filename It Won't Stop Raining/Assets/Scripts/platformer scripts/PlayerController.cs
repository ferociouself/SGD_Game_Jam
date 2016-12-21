using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	public Sprite holding,empty;
	bool hold;
	int direction; //-1 = left, 0 = none, 1=right
	GameObject heldObject;
	float holdDelay;
	Animator animator;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponent<Animator>();
		hold = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Left")){
			direction = -1;
		}else if(Input.GetButton("Right")){
			direction = 1;
		}

		if (Input.GetButtonDown("Activate") && holdDelay <= 0) {
			if (!hold) {
				RaycastHit2D[] objectsInFront = Physics2D.RaycastAll (gameObject.transform.position, new Vector2(direction,0), 0.5f);
				for (int i = 0; i < objectsInFront.Length; i++) {
					if (objectsInFront [i].collider.tag == "Movable") {
						hold = true;
						objectsInFront [i].collider.gameObject.SetActive(false);
						heldObject = objectsInFront [i].collider.gameObject;
						animator.SetBool("Interact", false);
					}
				}
			} else {
				heldObject.transform.position = new Vector2 (rb.transform.position.x + (direction) * 1, rb.transform.position.y);
				heldObject.SetActive (true);
				hold = false;
				//gameObject.GetComponent<SpriteRenderer> ().sprite = empty;
				animator.SetBool("Interact", false);
				//holdDelay = 0.5f;
			}
		}
	}
}
