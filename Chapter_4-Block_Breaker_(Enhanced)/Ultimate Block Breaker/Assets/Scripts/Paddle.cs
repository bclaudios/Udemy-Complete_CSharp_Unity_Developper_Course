using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {


	public static Vector3 paddleToBallVector;
	
	public bool autoPlay;
	public Sprite[] paddleSprite;

	private Ball ball;
	private float mousePos;
	private Vector3 paddlePos;
	private Brick brick;



	// Use this for initialization
	void Start () {
		Ball.hasStarted = false;
		ball = GameObject.FindObjectOfType<Ball> ();
		paddleToBallVector = ball.transform.position - this.transform.position;
		if (Brick.breakableCount <= 0) {
			this.GetComponent<SpriteRenderer> ().sprite = paddleSprite [0];
		}
	}

	// Update is called once per frame
	void Update () {
		if (autoPlay) {
			AutoPlay ();
		} else {
			mousePos = Input.mousePosition.x / Screen.width * 18;
			paddlePos = new Vector3 (Mathf.Clamp (mousePos, 2.8f, 15.2f), 0.7f, 0f);
			this.transform.position = paddlePos;
		}
	}



	void AutoPlay() {
		paddlePos = new Vector3 (Mathf.Clamp (ball.transform.position.x, 2.8f, 15.2f), 0.7f, 0f);
		this.transform.position = paddlePos;
	}

	public void LoadSprite() {
		int spriteIndex = LoseCollider.life;
		this.GetComponent<SpriteRenderer> ().sprite = paddleSprite [spriteIndex];
	}
}
