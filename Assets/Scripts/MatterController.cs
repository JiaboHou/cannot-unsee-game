using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class MatterController : MonoBehaviour {

	private Vector3 oldVelocity;
	private bool isReflected = false;

	void Start() {
		
	}

	void FixedUpdate() {
		oldVelocity = this.GetComponent<Rigidbody> ().velocity;
	}

	void OnCollisionEnter (Collision collision) {

		ContactPoint contact = collision.contacts [0];
		Vector3 reflectedVector = Vector3.Reflect (oldVelocity, contact.normal);

		switch (collision.collider.tag) {

		case("AntiMatterProjectile"):

			Destroy (this.gameObject);
			break;

		case("Barrier"):
			reflectedVector.y = 0;
			this.GetComponent<Rigidbody> ().velocity = reflectedVector;
			break;

		case("Enemy"):
			if (isReflected) {
				Destroy (this.gameObject);
			}
			break;

		case("Shield"):
			reflectedVector.y = 0;
			this.GetComponent<Rigidbody> ().velocity = reflectedVector;
			Physics.IgnoreLayerCollision (10, 12, false); //Collide with enemies
			Physics.IgnoreLayerCollision (10, 13, true); //Ignore collision with player
			this.GetComponent<Renderer>().material.SetColor ("_Color", Color.red);
			isReflected = true;
			break;

		case("Player"):
			
			Destroy (this.gameObject);
			break;

		case("Wall"):

			Destroy(this.gameObject);
			break;

		
		}

	}

	public bool getIsReflected() {
		return this.isReflected;
	}

}
