using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RhythmController : MonoBehaviour {

	Node[] master = { new Node (2.00f, 1.00f, Vector2.up) };
	Node[] mArr;
	List<GameObject> mDeployed;
	float mTime;

	// Use this for initialization
	void Start () {
		mArr = master;
		mTime = 0.00f;
		mDeployed = new List<GameObject> ();
	}

	// Update is called once per frame
	void Update () {
		mTime += Time.deltaTime;
		Node next = mArr [0];
		bool res = StaticMethods.AlmostEquals (next.getTime(), mTime, 1.5f * Time.deltaTime);
		if (res) {
			Debug.Log ("I have found your arrow, boi!");
			deployArrow (next.getSpeed(), next.getDir());//fire the next boi, send it on its way, add it to deployed, remove it from mArr
		}
	}

	private void deployArrow(float speed, Vector2 direction){
		string name = "Rhythm/" + direction.ToString();
		GameObject go = (GameObject)(Resources.Load("Prefabs/" + name, typeof(GameObject)));
		Rigidbody2D rb = go.GetComponent<Rigidbody2D> ();
		rb.transform.position =  Camera.main.ScreenToWorldPoint(this.gameObject.transform.position);
		rb.transform.position = Vector3();
		rb.velocity = direction * speed;
		mDeployed.Add (go);
		GameObject.Instantiate (go);
	}
}

public class Node {
	/// <summary>
	/// The time at which to send the arrow for this node.
	/// </summary>
	private float birthTime;
	/// <summary>
	/// The speed of that arrow.
	/// </summary>
	private float speed;
	/// <summary>
	/// The direction of that arrow.
	/// </summary>
	private Vector2 direction; //0, 1, 2, 3 for Up, Right, Down, Left

	/// <summary>
	/// Initializes a new instance of the <see cref="Node"/> class.
	/// </summary>
	/// <param name="bt">birthTime</param>
	/// <param name="s">speed</param>
	/// <param name="d">direction</param>
	public Node(float bt, float s, Vector2 d){
		this.birthTime = bt;
		this.speed = s;
		this.direction = d;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Node"/> class.
	/// </summary>
	/// <param name="bt">birthTime</param>
	/// <param name="s">speed</param>
	/// <param name="d">direction</param>
	public Node(float bt, float s, string d){
		this.birthTime = bt;
		this.speed = s;
		setDir (d);
	}

	/// <summary>
	/// Gets the birth time.
	/// </summary>
	/// <returns>The time.</returns>
	public float getTime(){
		return birthTime;
	}

	/// <summary>
	/// Gets the speed.
	/// </summary>
	/// <returns>The speed.</returns>
	public float getSpeed(){
		return speed;
	}

	/// <summary>
	/// Gets the direction.
	/// </summary>
	/// <returns>The dir.</returns>
	public Vector2 getDir(){
		return direction;
	}

	/// <summary>
	/// Sets the birth time.
	/// </summary>
	/// <param name="bt">birthTime</param>
	public void setTime(float bt){
		this.birthTime = bt;
	}

	/// <summary>
	/// Sets the speed.
	/// </summary>
	/// <param name="s">speed</param>
	public void setSpeed(float s){
		this.speed = s;
	}

	/// <summary>
	/// Sets the direction
	/// </summary>
	/// <param name="d">direction</param>
	public void setDir(Vector2 d){
		this.direction = d;
	}

	/// <summary>
	/// Sets the direction from a string
	/// </summary>
	/// <param name="d">direction string</param>
	public void setDir(string d){
		string dl = d.ToLower ();
		if (dl.Equals ("up")) {
			this.direction = Vector2.up;
		} else if (dl.Equals ("right")) {
			this.direction = Vector2.right;
		} else if (dl.Equals ("down")) {
			this.direction = Vector2.down;
		} else if (dl.Equals ("left")) {
			this.direction = Vector2.left;
		} else {
			Debug.LogError ("The passed string matches neither up, right, down, nor left.");
		}
	}
}