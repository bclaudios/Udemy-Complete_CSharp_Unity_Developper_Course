using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;

	private LevelManager levelManager;
	private MusicManager musicManager;

	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}

	void Update() {
		musicManager.ChangeVolume (volumeSlider.value);
	}

	public void SetDefault() {
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}

	public void SaveAndExit() {
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		levelManager.LoadLevel ("01 Menu");
	}
}
