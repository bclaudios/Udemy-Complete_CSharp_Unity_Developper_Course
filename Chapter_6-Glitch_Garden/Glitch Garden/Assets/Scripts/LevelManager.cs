using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start ()
	{
		if (autoLoadNextLevelAfter > 0) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}


	public void LoadLevel(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
