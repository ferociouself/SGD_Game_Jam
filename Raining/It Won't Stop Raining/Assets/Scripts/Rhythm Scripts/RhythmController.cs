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

	float delayTime = 0;

	public GameObject arrowL;
	public GameObject arrowB;

	// Use this for initialization
	void Start () {
		float numerator = Mathf.Abs (Camera.main.ScreenToWorldPoint (arrowB.transform.position).y);
		float dominator = Mathf.Abs (Camera.main.ScreenToWorldPoint (arrowL.transform.position).x);
		SPEED_V = numerator/dominator * SPEED_H;

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

		mArr.Add(new Node (GenBirthTime(17.987f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(18.358f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(18.823f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(19.194f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(19.600f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(21.512f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(22.000f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(22.577f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(23.164f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(23.776f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(24.920f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(25.363f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(25.628f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(26.106f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(26.477f), SPEED_V, Vector2.up));

		mArr.Add(new Node (GenBirthTime(27.957f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(28.328f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(28.607f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(30.576f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(30.970f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(31.268f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(31.640f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(32.104f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(34.994f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(35.290f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(35.644f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(37.223f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(37.781f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(38.470f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(38.850f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(39.100f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(41.826f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(42.383f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(42.550f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(44.155f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(44.712f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(45.340f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(45.733f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(46.100f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(48.809f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(49.200f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(49.552f), SPEED_H, Vector2.right));	
		mArr.Add(new Node (GenBirthTime(54.925f), SPEED_H, Vector2.right)); //long notes
		mArr.Add(new Node (GenBirthTime(55.204f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(55.854f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(56.226f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(56.500f), SPEED_H, Vector2.right));


		mArr.Add(new Node (GenBirthTime(58.113f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(58.400f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(58.763f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(58.900f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(59.100f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(59.310f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(59.650f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(60.000f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(61.850f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(62.686f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(65.600f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(66.230f), SPEED_H, Vector2.left));

		mArr.Add(new Node (GenBirthTime(66.694f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(67.159f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(67.344f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(67.716f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(68.087f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(68.400f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(68.799f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(69.109f), SPEED_V, Vector2.up));

		mArr.Add(new Node (GenBirthTime(69.730f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(72.035f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(72.140f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(72.263f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(72.981f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(73.100f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(73.217f), SPEED_H, Vector2.left));

		mArr.Add(new Node (GenBirthTime(74.590f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(74.693f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(74.796f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(74.900f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(75.050f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(76.602f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(76.725f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(76.849f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(76.973f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(76.143f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(76.284f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(77.400f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(77.470f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(77.563f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(77.888f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(78.213f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(78.400f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(78.583f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(78.766f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(78.950f), SPEED_V, Vector2.down));

		mArr.Add(new Node (GenBirthTime(79.100f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(79.211f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(79.323f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(80.098f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(80.250f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(80.411f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(80.573f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(80.734f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(81.605f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(81.744f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(81.884f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(81.884f), SPEED_V, Vector2.down));

		mArr.Add(new Node (GenBirthTime(83.269f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(83.269f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(83.400f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(83.400f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(83.530f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(83.530f), SPEED_H, Vector2.left));//climax, rock-maninov!

		mArr.Add(new Node (GenBirthTime(86.316f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(86.706f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(87.174f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(87.400f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(89.369f), SPEED_V, Vector2.down));

		mArr.Add(new Node (GenBirthTime(91.214f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(92.974f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(93.200f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(93.624f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(94.000f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(95.553f), SPEED_V, Vector2.down));

		mArr.Add(new Node (GenBirthTime(97.590f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(97.590f), SPEED_H, Vector2.left));

		mArr.Add(new Node (GenBirthTime(99.865f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(100.102f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(100.357f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(100.543f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(100.822f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(100.938f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(101.403f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(101.700f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(104.650f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(104.932f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(105.120f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(106.852f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(107.038f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(107.316f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(107.761f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(108.059f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(108.368f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(108.646f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(111.379f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(111.844f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(112.112f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(113.777f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(114.149f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(114.242f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(114.613f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(114.892f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(115.370f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(115.600f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(118.395f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(118.673f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(119.138f), SPEED_H, Vector2.right));

		mArr.Add(new Node (GenBirthTime(120.800f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(120.964f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(121.243f), SPEED_H, Vector2.right));
		mArr.Add(new Node (GenBirthTime(121.615f), SPEED_V, Vector2.up));
		mArr.Add(new Node (GenBirthTime(121.893f), SPEED_H, Vector2.left));
		mArr.Add(new Node (GenBirthTime(122.265f), SPEED_V, Vector2.down));
		mArr.Add(new Node (GenBirthTime(122.600f), SPEED_H, Vector2.right));


		mArr.Add(new Node (GenBirthTime(20000.477f), SPEED_V, Vector2.up));

		mIndex = 0;
		mTime = 0.00f;
		mDeployed = new List<GameObject> ();
	}

	// Update is called once per frame
	void Update () {
		mTime += Time.deltaTime;
		//bool res = StaticMethods.AlmostEquals (next.getTime(), mTime, 2.0f * Time.deltaTime);
		if (mIndex < mArr.Count - 1) {
			Node next = mArr [mIndex];
			if (mTime >= next.getTime ()) {
				deployArrow (next.getSpeed (), next.getDir ());//fire the next boi, send it on its way, add it to deployed, remove it from mArr
				if (mIndex < mArr.Count - 1) { 
					mIndex++; 
				}
			}
		} else {
			if(mDeployed.Count <= 0){
				delayTime += Time.deltaTime;
				if(delayTime >= 5.0){
					Debug.Log ("I am done, Sir.");
					SceneManager SM = GameObject.Find ("SceneManager").GetComponent<SceneManager>();
					SM.MoveToScene (0); //THe ENd				}
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
		return (hit - (Mathf.Abs (Camera.main.ScreenToWorldPoint (arrowL.transform.position).x)) / SPEED_H);
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