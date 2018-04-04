using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationSpawner : MonoBehaviour {

	public GameObject[] formationsList;
	public int palierT2, palierT3;


	private int randFormation;




	void Update() {
		if (transform.childCount == 0) {
			SpawnFormation ();
		}
	}




	void SpawnFormation() {
		if (Score.score < palierT2) {
			randFormation = Random.Range (0, 3);
		} else if (Score.score < palierT3) {
			randFormation = Random.Range (4, 7);
		} else {
			randFormation = Random.Range (8, 11);
		}
		GameObject newFormation = Instantiate (formationsList [randFormation], transform.position, Quaternion.identity) as GameObject;
		newFormation.transform.parent = transform;
	}
}
