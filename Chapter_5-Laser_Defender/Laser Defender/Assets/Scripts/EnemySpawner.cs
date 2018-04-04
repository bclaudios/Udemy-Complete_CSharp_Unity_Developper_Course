using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyShip1;
	public float width = 10f;
	public float height = 5f;
	public float speed;
	public float spawnDelay;

	private GameObject enemy;
	private float xMin, xMax;
	private Vector3 direction;
	private bool movingRight = true;



	void Start () {
		EdgesDefinition ();
		SpawnEnemy ();
	}

	void Update() {
		EnemyMovement ();
		if (AllMembersAreDead()) {
			SpawnEnemy ();
		}
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}

	Transform NextFreePosition () {
		foreach (Transform enemyGameObject in transform) {
			if (enemyGameObject.childCount <= 0) {
				return enemyGameObject;
			}
		}
		return null;
	}

	bool AllMembersAreDead() {
		foreach (Transform enemyGameObject in transform) {
			if (enemyGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	void EdgesDefinition () {
		float zDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, zDistance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, zDistance));
		xMin = leftMost.x;
		xMax = rightMost.x;
	}

	void EnemyMovement() {
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float leftFormationEdge = transform.position.x - (width / 2);
		float rightFormationEdge = transform.position.x + (width / 2);
		if (leftFormationEdge <= xMin) {
			movingRight = true;
		} else if (rightFormationEdge >= xMax) {
			movingRight = false;
		}
	}

	void SpawnEnemy() {
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			enemy = Instantiate (enemyShip1, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition()) {
			Invoke ("SpawnEnemy", spawnDelay);
		}
	}
}
