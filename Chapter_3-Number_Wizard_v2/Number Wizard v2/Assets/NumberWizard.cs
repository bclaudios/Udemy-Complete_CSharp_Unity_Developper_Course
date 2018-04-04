using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
	string response;
	public int maxGuessesAllowed = 10;
	public Text text;

	// Use this for initialization
	void Start() {
		GameStart();
	}

	void GameStart() {
		max = 1000;
		min = 1;
		guess = Random.Range(min, (max + 1));
		text.text = "Is your number " + guess + " ?";
	}

	public void GuessHigher() {
		response = "Higher";
		min = guess;
		NextGuess();
	}

	public void GuessLower() {
		response = "Lower";
		max = guess;
		NextGuess();
	}

	void NextGuess () {
		guess = Random.Range(min, (max + 1));
		maxGuessesAllowed -= 1;
		if (maxGuessesAllowed <= 0) {
			SceneManager.LoadScene("Win");
		}
		string[] dialog = new string[] {response + " ok ! Is it " + guess + " ?",
										"AH ! Let's see ... " + guess + " ?",
										"I know ! That's " + guess + " right ?",
										response + " ... " + guess + " ?"};
		text.text = dialog[Random.Range(0, 4)];
	}
}