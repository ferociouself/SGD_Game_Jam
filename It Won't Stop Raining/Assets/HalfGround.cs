using UnityEngine;
using System.Collections;

public class HalfGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider hit) {
        var p = transform.parent;
        Physics.IgnoreCollision(hit.GetComponent<CharacterController>(), 
            p.GetComponent<BoxCollider>());
    }

    void OnTriggerExit(Collider hit) {
        var p = transform.parent;
        Physics.IgnoreCollision(hit.GetComponent<CharacterController>(),
            p.GetComponent<BoxCollider>(), false);
        
    }
}
