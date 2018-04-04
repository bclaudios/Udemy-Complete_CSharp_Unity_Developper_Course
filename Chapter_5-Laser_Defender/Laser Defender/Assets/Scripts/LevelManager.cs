using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	static int previousSCeneIndex;

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
}
