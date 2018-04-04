using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {

	public int defenderCost;

	private StarDisplay starDisplay;

	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();	
	}

	void AddStars(int amount) {
		starDisplay.AddStars (amount);
	}
}