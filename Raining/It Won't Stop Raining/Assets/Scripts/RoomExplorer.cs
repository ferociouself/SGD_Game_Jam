using UnityEngine;
using System.Collections;

public class RoomExplorer : MonoBehaviour {

	public GameObject parents;
	public GameObject hall;
	public GameObject kids;
	public GameObject bath;
	public GameObject living;
	public GameObject kitchen;
	public GameObject laundry;
	public GameObject attic;
	public GameObject basement;

	private Color dark;
	private Color dim;
	private Color lit;

	// Use this for initialization
	void Start () {
		dark = new Color(0x49,0x49,0x49,0xFF);
		dim = new Color(0xB0,0xB0,0xB0,0xFF);
		lit = new Color (0xFF,0xFF,0xFF,0xFF);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
