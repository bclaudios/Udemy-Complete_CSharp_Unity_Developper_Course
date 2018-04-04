using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	public static int previousSCeneIndex;



	public void LoadScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void LoadNextScene() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene (previousSCeneIndex + 1);	
	}

	public void LoadPreviousLevel() {
		SceneManager.LoadScene (previousSCeneIndex);
	}

	public void Win() {
		if (Brick.breakableCount == 0) {
			if (SceneManager.GetActiveScene ().name == "Level_10") {
				LoadScene ("Win_Screen");
			} else {
				previousSCeneIndex = SceneManager.GetActiveScene ().buildIndex;
				LoadScene ("Level_Cleared");
			}
		}
	}

	public void GetPreviousSceneIndex() {
		previousSCeneIndex = SceneManager.GetActiveScene().buildIndex;
	}
}
