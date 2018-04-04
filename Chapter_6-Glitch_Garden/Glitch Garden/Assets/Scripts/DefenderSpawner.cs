using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject defenderParent;
	private StarDisplay starDisplay;

	void Start() {
		defenderParent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		if (!defenderParent) {
			defenderParent = new GameObject ("Defenders");
		} else {
			return;
		}
	}

	void OnMouseDown() {
		if (Button.selectedDefender) {
			int defenderCost = Button.selectedDefender.GetComponent<Defenders> ().defenderCost;
			if (starDisplay.UseStarts (defenderCost) == StarDisplay.Status.SUCCESS) {
				Vector2 spawnPosition = SnapToGrid (CalculateWorldPointOfMouseClick ());
				SpawnDefender (Button.selectedDefender, spawnPosition);
			} else {
				Debug.Log ("Not enough stars");
			}
		}
	}

	void SpawnDefender (GameObject defender, Vector2 spawnPosition) {
		GameObject newDefender = Instantiate (defender, spawnPosition, Quaternion.identity);
		newDefender.transform.parent = defenderParent.transform;
	}

	Vector2 SnapToGrid(Vector2 rawWorldPosition) {
		int roundedX = Mathf.RoundToInt(rawWorldPosition.x);
		int roundedY = Mathf.RoundToInt (rawWorldPosition.y);
		return new Vector2 (roundedX, roundedY);
	}

	Vector2 CalculateWorldPointOfMouseClick() {
		// Créé un Vector3 avec la position en pixel de la souris
		float newX = Input.mousePosition.x;
		float newY = Input.mousePosition.y;
		float zDistance = 10f;
		Vector3 weirdTriplet = new Vector3 (newX, newY, zDistance);
		// Transpose le Vector3 de la position de la souris en pixel en Vector 2 de la position en World Point
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);
		// Retourne le Vector2
		return worldPos;
	}
}
