using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController: MonoBehaviour {

	public float fireInterval = 0.5f;
	public float fireDelay = 0.5f;
	public float projectileSpeed = 10f;

	private bool isShooting = false;

	GameObject matterProjectilePrefab;

	// Use this for initialization
	void Start () {
		matterProjectilePrefab = Resources.Load ("Matter Projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		var playerObject = GameObject.Find ("Player");
		var playerLocation = playerObject.transform.position;

		this.transform.LookAt (playerLocation);

		if (Vector3.Distance (playerLocation, this.transform.position) <= 10 && !isShooting) {
			isShooting = true;
			InvokeRepeating ("Shoot", fireDelay, fireInterval);
		} else if (Vector3.Distance (playerLocation, this.transform.position) > 10) {
			CancelInvoke ("Shoot");
			isShooting = false;
		}

	}

	void Shoot() {
		var projectile = Instantiate (matterProjectilePrefab, this.transform.position + this.transform.forward * 0.55f, this.transform.rotation);
		projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * projectileSpeed;
		Destroy (projectile, 5f);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "MatterProjectile" && collision.collider.GetComponent<MatterController> ().getIsReflected ()) {
			Destroy (this.gameObject);
		}
	}
}
