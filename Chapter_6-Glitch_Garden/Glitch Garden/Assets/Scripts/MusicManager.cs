using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audio;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	void Start() {
		audio = GetComponent<AudioSource>();
		audio.volume = PlayerPrefsManager.GetMasterVolume ();
	}


	public void ChangeVolume(float volume) {
		audio.volume = volume;
	}

	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if (thisLevelMusic) {
			audio.clip = thisLevelMusic;
			audio.Play();
			audio.loop = true;
		}
	}
		
}
