using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class RhythmController : MonoBehaviour {

	public float SPEED_H = 1.0f;
	float SPEED_V;
	
	List<Node> mArr;
    List<GameObject> mDeployed;
	int mIndex;
	float mTime;

	// Use this for initialization
	void Start () {
		SPEED_V = 3.55f/6.94f * SPEED_H;

		mArr = new List<Node>();
		mArr.Add(new Node (GenBirthTime(7.159f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(7.430f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(7.702f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(8.100f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(8.638f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(9.009f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(9.288f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(9.381f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(9.567f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(9.752f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(9.938f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(10.124f), SPEED_V, Vector2.up));

		mArr.Add(new Node (GenBirthTime(10.550f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(11.000f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(11.200f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(11.547f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(12.074f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(12.360f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(12.650f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(12.901f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(13.101f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(13.350f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(13.560f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(13.775f), SPEED_V, Vector2.up));

		mArr.Add(new Node (GenBirthTime(14.200f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(14.391f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(14.950f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(15.600f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(15.950f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(16.250f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(16.600f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(17.100f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(17.400f), SPEED_H, Vector2.left));



		//dummy node at the end

		mIndex = 0;
		mTime = 0.00f;
		mDeployed = new List<GameObject> ();
	}

	// Update is called once per frame
	void Update () {
		mTime += Time.deltaTime;
		Node next = mArr [mIndex];
		//bool res = StaticMethods.AlmostEquals (next.getTime(), mTime, 2.0f * Time.deltaTime);
		if (mIndex < mArr.Count - 1){
			if (mTime >= next.getTime()) {
				deployArrow (next.getSpeed(), next.getDir());//fire the next boi, send it on its way, add it to deployed, remove it from mArr
				if(mIndex < mArr.Count - 1){ 
					mIndex++; 
				}
			}
		}			
	}

	/// <summary>
	/// Deploies the arrow as necessary.
	/// </summary>
	/// <param name="speed">Speed.</param>
	/// <param name="direction">Direction.</param>
	private void deployArrow(float speed, Vector2 direction){
		string path = "Prefabs/Rhythm/" + direction.ToString();
		GameObject go = (GameObject)(Resources.Load(path, typeof(GameObject)));
		go.transform.position =  Camera.main.ScreenToWorldPoint(this.gameObject.transform.position);
		go.transform.position = StaticMethods.SetZOf(go.transform.position, 0.00f);
		GameObject boi = GameObject.Instantiate (go);
		boi.GetComponent<Rigidbody2D> ().velocity = direction * speed;
		mDeployed.Add (boi);
	}

	public List<GameObject> getDeployed(){
		return mDeployed;
	}

	private float GenBirthTime(float hit){
		return hit - (Mathf.Abs(6.94f) / SPEED_H);
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