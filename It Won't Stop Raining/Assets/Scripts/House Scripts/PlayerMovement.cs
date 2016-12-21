using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float speed = 1.0f;
	public float jumpForce = 1.0f;

	public float timer;
    [HideInInspector]
    public Vector2 direction;
	Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
		timer = 0.00f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer < 5.00f) {
			timer += Time.deltaTime;
		}

		if (timer >= 0.20f && timer < 0.50f) {
			if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 0) {
				SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager> ();
				this.gameObject.transform.position = SM.getPlayerPos ();
			}
		}

		float horiz = Input.GetAxis ("Horizontal") * speed;
        if (Mathf.Abs(horiz) > 0) direction.x = horiz;

		rb.velocity = new Vector2 (direction.x, rb.velocity.y);
		gameObject.GetComponent<Animator> ().SetBool ("Moving", (rb.velocity.magnitude > 0.1));
		gameObject.GetComponent<SpriteRenderer> ().flipX = (direction.x < 0);

		if (Input.GetButtonDown ("Jump")) {
			rb.AddForce (Vector2.up * jumpForce);
		}

        if (Input.GetButtonDown("Cancel")){
            Application.Quit();
        }

    }
}
