using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {

	public float width, height;

	public GameObject[] planetList;
	public float planetSpawnRate;
	public float planetSpeed;

	private float xMin, xMax;


	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
	// Use this for initialization
	void Start () {
		DefineEdges ();
	}
	
	// Update is called once per frame
	void Update () {
		float probability = Time.deltaTime * planetSpawnRate;
		if (Random.value <= probability) {
			SpawnPlanet ();
		}
	}

	void DefineEdges() {
		float zDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, zDistance));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, zDistance));
		xMin = leftEdge.x;
		xMax = rightEdge.x;
	}

	void SpawnPlanet() {
		int randomIndex = Random.Range (0, planetList.Length);
		float randomXPos = Random.Range (xMin, xMax);
		Vector3 randomPosition = new Vector3 (randomXPos, transform.position.y);
		GameObject planet = Instantiate (planetList[randomIndex], randomPosition, Quaternion.identity) as GameObject;
		planet.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -planetSpeed);
	}
}
