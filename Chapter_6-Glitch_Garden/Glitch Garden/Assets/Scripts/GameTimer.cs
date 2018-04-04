using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelDuration;

	private Slider timerSlider;
	private GameObject winText;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private bool isEndOfLevel = false;

	void Start() {
		timerSlider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		winText = GameObject.Find ("Win Text");
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		winText.SetActive (false);
	}

	void Update() {
		timerSlider.value = Time.timeSinceLevelLoad / levelDuration;
		if(Time.timeSinceLevelLoad >= levelDuration && !isEndOfLevel) {
			Win ();
		}
	}

	void Win() {
		Time.timeScale = 0.0f;
		audioSource.Play ();
		winText.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel ();
	}
}
