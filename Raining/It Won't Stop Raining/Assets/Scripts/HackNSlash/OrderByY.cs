using UnityEngine;
using System.Collections;

public class OrderByY : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.z = pos.y;
        transform.position = pos;
	}
}
