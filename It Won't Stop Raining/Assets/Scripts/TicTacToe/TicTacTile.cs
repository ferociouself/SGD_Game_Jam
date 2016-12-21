using UnityEngine;
using System.Collections;

public class TicTacTile : MonoBehaviour
{

	public int state; //0 = empty, 1 = X, 2 = O
	public Sprite empty, xImage, oImage;
	public TicTacToeManager parent;
	public int x,y;


	// Use this for initialization
	void Start ()
	{
		state = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown(){
		parent.handleClick (this);
	}
}

