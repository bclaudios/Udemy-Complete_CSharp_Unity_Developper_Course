using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private EnnemySpawner myLaneSpawner;

	void Start() {
		projectileParent = GameObject.Find ("Projectiles");
		animator = GetComponent<Animator> ();
		SetMyLaneSpawner ();
		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		} else {
			return;
		}
	}

	void Update() {
		if (IsAttackerAheadInLane()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	void SetMyLaneSpawner() {
		EnnemySpawner[] ennemySpawnerArray = GameObject.FindObjectsOfType<EnnemySpawner> ();
		foreach (EnnemySpawner ennemySpawner in ennemySpawnerArray) {
			if (ennemySpawner.transform.position.y == transform.position.y) {
				myLaneSpawner = ennemySpawner;
				Debug.Log ("Spawner defined");
				return;
			}
			Debug.LogWarning (name + " no spawner found on this lane.");
		}
	}

	bool IsAttackerAheadInLane() {
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		foreach (Transform child in myLaneSpawner.transform) {
			if (child.transform.position.x > transform.position.x) {
				return true;
			}
		}
		return false;
	}

	private void FireGun() {
		GameObject newProjectile = Instantiate (projectile);
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
