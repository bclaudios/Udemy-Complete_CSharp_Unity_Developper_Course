using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score;


	private Text text;




	void Start() {
		text = GetComponent<Text>();
	}

	void Update() {
		text.text =	score.ToString();
	}




	public void AddScore(int scoreAd) {
		score += scoreAd;
	}
}