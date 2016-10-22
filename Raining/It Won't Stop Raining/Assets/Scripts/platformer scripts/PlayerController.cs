using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	public Sprite holding,empty;
	bool hold;
	int direction; //-1 = left, 0 = none, 1=right
	GameObject heldObject;
	float holdDelay;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		hold = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (holdDelay >= 0) {
			holdDelay -= Time.deltaTime;
		}
		if (Input.GetAxis ("Vertical") > 0 && rb.velocity.y == 0) {
			rb.velocity = new Vector2(rb.velocity.x,10);
		}
		rb.velocity = new Vector2(Input.GetAxis("Horizontal")*3,rb.velocity.y);
		if (Input.GetAxis ("Horizontal") > 0) {
			direction = 1;
		} else if (Input.GetAxis ("Horizontal") < 0) {
			direction = -1;
		}
		if (Input.GetAxis ("Vertical") < 0 && holdDelay <= 0) {
			if (!hold) {
				
				RaycastHit2D[] objectsInFront = Physics2D.RaycastAll (gameObject.transform.position, new Vector2(direction,0), 0.5f);
				for (int i = 0; i < objectsInFront.Length; i++) {
					if (objectsInFront [i].collider.tag == "Movable") {
						hold = true;
						objectsInFront [i].collider.gameObject.SetActive(false);
						heldObject = objectsInFront [i].collider.gameObject;
						gameObject.GetComponent<SpriteRenderer> ().sprite = holding;
						holdDelay = 1;
					}
				}
			} else {
				heldObject.transform.position = new Vector2 (rb.transform.position.x + (direction) * 1, rb.transform.position.y);
				heldObject.SetActive (true);
				hold = false;
				gameObject.GetComponent<SpriteRenderer> ().sprite = empty;
				holdDelay = 1;
			}
		}
	}
}
