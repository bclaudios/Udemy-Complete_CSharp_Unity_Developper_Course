using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};

	private Text starText;
	public int playerStarsAmount;

	void Start() {
		starText = GetComponent<Text> ();
	}

	public void AddStars(int amount) {
		playerStarsAmount += amount;
		UpdateDisplay ();
	}

	public Status UseStarts(int amount) {
		if (playerStarsAmount >= amount) {
			playerStarsAmount -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	private void UpdateDisplay() {
		starText.text = playerStarsAmount.ToString ();
	}
}
