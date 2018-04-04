using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {


	public static int ballNumber;
	public static int life;

	public bool menuScene;

	private LevelManager levelManager;
	private Paddle paddle;
	private AudioSource audio;


	// Use this for initialization
	void Start () {
		ballNumber = 0;
		life = 3;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		paddle = GameObject.FindObjectOfType<Paddle> ();
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		if (!menuScene) {
			ballNumber--;
			if (ballNumber == 0) {
				Brick.bonusCountdown = 10;
				life--;
				if (life <= 0) {
					Brick.breakableCount = 0;
					levelManager.GetPreviousSceneIndex ();
					levelManager.LoadScene ("Lose_Screen");
				} else {
					print ("allo");
					paddle.LoadSprite ();
					Ball.hasStarted = false;
					ballNumber++;
				}
			} else {
				Destroy (trigger.gameObject);
				audio.Play ();
			}
		} else {
			Ball.hasStarted = false;
		}
	}
}
