using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController: MonoBehaviour {

	public float fireInterval;
	public float projectileSpeed = 10f;

	private bool isShooting = false;

	GameObject matterProjectilePrefab;

	// Use this for initialization
	void Start () {
		matterProjectilePrefab = Resources.Load ("Matter Projectile") as GameObject;
		Debug.Log (matterProjectilePrefab);
	}
	
	// Update is called once per frame
	void Update () {
		var playerObject = GameObject.Find ("Player");
		var playerLocation = playerObject.transform.position;

		this.transform.LookAt (playerLocation);

		if (Vector3.Distance (playerLocation, this.transform.position) <= 10 && !isShooting) {
			isShooting = true;
			InvokeRepeating ("Shoot", 0.5f, fireInterval);
		} else if (Vector3.Distance (playerLocation, this.transform.position) > 10) {
			CancelInvoke ("Shoot");
			isShooting = false;
		}

	}

	void Shoot() {
		var projectile = Instantiate (matterProjectilePrefab, this.transform.position + this.transform.forward, this.transform.rotation);
		projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * projectileSpeed;
		Destroy (projectile, 2f);
	}
}
