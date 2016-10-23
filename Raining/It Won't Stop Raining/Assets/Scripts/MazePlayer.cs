using UnityEngine;
using System.Collections;

public class MazePlayer : MonoBehaviour {

	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;
	public GameObject bg;
	public Sprite spr;
	private Texture2D heightmap;
	public Vector3 size = new Vector3(100, 10, 100);

	// Use this for initialization
	void Start () {
		size = spr.border;
		heightmap = spr.texture;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			detectCollision ();
			followMouse ();
		}
//		if (detectCollision ()) {
//			Application.LoadLevel (0);
//		}
	}

	void followMouse() {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
	}

	void detectCollision() {
//		Color32[] pix = heightmap.GetPixels32();
//
//		int x = Mathf.FloorToInt(mousePosition.x / size.x * heightmap.width);
//		int x = Mathf.FloorToInt(mousePosition.x);
//		int y = Mathf.FloorToInt (mousePosition.y);
		int x = Mathf.FloorToInt(transform.position.x);
		int y = Mathf.FloorToInt (transform.position.y);
//		int y = Mathf.FloorToInt(mousePosition.y / size.x * heightmap.width);
//		int z = Mathf.FloorToInt(transform.position.z / size.z * heightmap.height);
//		Vector3 pos = Input.mousePosition;
		Debug.Log(x + "," + y);
		Color myPixel = heightmap.
			GetPixel(x,y);
		Debug.Log (myPixel*255);
//		pos.y = heightmap.GetPixel(x, z).grayscale * size.y;
//		transform.position = pos;



	}
}
