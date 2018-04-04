using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {


	private LevelManager levelManager;



	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		switch (this.name) {
		case "PlayButtonCollider":
			levelManager.LoadScene ("Level_01");
			break;
		case "SelectLevelButtonCollider":
			levelManager.LoadScene ("Select_Level");
			break;
		case "MenuButtonCollider":
			levelManager.LoadScene ("Start Screen");
			break;
		case "Level1ButtonCollider":
			levelManager.LoadScene ("Level_01");
			break;
		case "Level2ButtonCollider":
			levelManager.LoadScene ("Level_02");
			break;
		case "Level3ButtonCollider":
			levelManager.LoadScene ("Level_03");
			break;
		case "Level4ButtonCollider":
			levelManager.LoadScene ("Level_04");
			break;
		case "Level5ButtonCollider":
			levelManager.LoadScene ("Level_05");
			break;
		case "Level6ButtonCollider":
			levelManager.LoadScene ("Level_06");
			break;
		case "Level7ButtonCollider":
			levelManager.LoadScene ("Level_07");
			break;
		case "Level8ButtonCollider":
			levelManager.LoadScene ("Level_08");
			break;
		case "Level9ButtonCollider":
			levelManager.LoadScene ("Level_09");
			break;
		case "Level10ButtonCollider":
			levelManager.LoadScene ("Level_10");
			break;
		case "NextLevelButtonCollider":
			levelManager.LoadNextLevel ();
			break;
		case "RetryButtonCollider":
			levelManager.LoadPreviousLevel ();
			break;
		}
	}
}
