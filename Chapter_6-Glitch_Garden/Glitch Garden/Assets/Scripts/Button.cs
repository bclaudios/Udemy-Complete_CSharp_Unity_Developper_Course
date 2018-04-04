using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {


	public static GameObject selectedDefender;
	public GameObject defender;

	private Button[] buttonArray;
	private Text costText;

	void Start() {
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		costText = GetComponentInChildren<Text>();
		costText.text = defender.GetComponent<Defenders> ().defenderCost.ToString ();
	}

	void OnMouseDown() {
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defender;
	}
}
