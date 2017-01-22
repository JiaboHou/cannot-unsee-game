using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision) {
		if(collision.collider.tag == "Shield") {
			ContactPoint contact = collision.contacts [0];
		}
	}
}
