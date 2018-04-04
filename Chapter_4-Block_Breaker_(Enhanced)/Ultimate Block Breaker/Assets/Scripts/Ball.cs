using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


	public static bool hasStarted;

	public Rigidbody2D ballRigidBody;
	public GameObject ball;
	public float speedBonusSpeed;
	public float strengthBonusDuration;

	private AudioSource audio;
	private Paddle paddle;
	private GameObject collisionObject;
	private float ballOnPaddlePos;
	private float newXVel;
	private float totalBallVel;



	// Use this for initialization
	void Start () {
		LoseCollider.ballNumber += 1;
		audio = GetComponent<AudioSource> ();
		ballRigidBody = this.GetComponent<Rigidbody2D> ();
		paddle = GameObject.FindObjectOfType<Paddle> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + Paddle.paddleToBallVector;
			if (Input.GetMouseButtonDown(0)) {
				if (Brick.breakableCount > 0) {
					ballRigidBody.velocity = new Vector2 (2f, 7f);
				} else {
					ballRigidBody.velocity = new Vector2 (0f, 7f);
				}
			hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		collisionObject = collision.gameObject;
		if (collisionObject.name == "Paddle" && hasStarted && !paddle.autoPlay) {
			PaddleHit ();
		} else if (collisionObject.name == "Paddle" && hasStarted && paddle.autoPlay) {
			ballRigidBody.velocity = new Vector2 ((ballRigidBody.velocity.x + Random.Range(-0.5f,0.5f)), 7.0f);
		}
		if (collisionObject.tag != "Breakable") {
			PlaySound ();
		} 
	}



	void PaddleHit() {
		totalBallVel = Mathf.Clamp (Mathf.Abs (ballRigidBody.velocity.x) + Mathf.Abs (ballRigidBody.velocity.y), -15.0f, 15.0f);
		ballOnPaddlePos = Mathf.Clamp((this.transform.position.x - paddle.transform.position.x), -0.7f, 0.7f);
		newXVel = ballOnPaddlePos * 10;
		if (ballOnPaddlePos < 0) {
			ballRigidBody.velocity = new Vector2 (newXVel, Mathf.Clamp((totalBallVel + newXVel), -10f, 10f));
		} else if (ballOnPaddlePos > 0) {
			ballRigidBody.velocity = new Vector2 (newXVel, Mathf.Clamp((totalBallVel - newXVel), -10f, 10f));
		}
	}

	void PlaySound() {
		if (Mathf.Abs(ballRigidBody.velocity.x) < Mathf.Abs(ballRigidBody.velocity.y)) {
			audio.volume = Mathf.Abs(ballRigidBody.velocity.y / 40);
		} else {
			audio.volume = Mathf.Abs(ballRigidBody.velocity.x / 40);
		}
		audio.Play ();
	}




	public void UpSpeedBonus() {
		ballRigidBody.velocity = new Vector2 ((ballRigidBody.velocity.x * speedBonusSpeed), (ballRigidBody.velocity.y * speedBonusSpeed));
	}

	public void DownSpeedBonus() {
		ballRigidBody.velocity = new Vector2 ((ballRigidBody.velocity.x / speedBonusSpeed), (ballRigidBody.velocity.y / speedBonusSpeed));
	}

	public void MultiBallBonus() {
		GameObject firstBonusBall = Instantiate (ball, transform.position, Quaternion.identity) as GameObject;
		firstBonusBall.GetComponent<Rigidbody2D>().velocity = new Vector2 ((ballRigidBody.velocity.x + 2), (ballRigidBody.velocity.y - 2));
		GameObject secondBonusBall = Instantiate (ball, transform.position, Quaternion.identity) as GameObject;
		secondBonusBall.GetComponent<Rigidbody2D>().velocity = new Vector2 ((ballRigidBody.velocity.x - 2), (-ballRigidBody.velocity.y + 2));
	}

	public void LaunchStrengthBonus() {
		StartCoroutine(StrengthBonus());
	}

	IEnumerator StrengthBonus() {
		SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
		print("Strength Bonus Started");
		Brick.ballStrength = 10;
		spriteRenderer.color = new Color  (255f, 0f, 0f, 1f);
		yield return new WaitForSeconds(strengthBonusDuration);
		spriteRenderer.color = new Color (0f, 255f, 255f, 1f);
		Brick.ballStrength = 1;
		print ("Strength Bonus Ended");
	}
}
