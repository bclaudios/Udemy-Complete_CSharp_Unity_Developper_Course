using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score;

	private Text scoreUI;

	void Start() {
		scoreUI = GetComponent<Text> ();
		Reset ();
	}

	public void Score(int points) {
		score += points;
		scoreUI.text = score.ToString ();
	}

	public void Reset() {
		score = 0;
		scoreUI.text = score.ToString ();
	}
}