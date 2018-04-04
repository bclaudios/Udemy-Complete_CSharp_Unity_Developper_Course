using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {


	public static int ballStrength;
	public static int breakableCount = 0;
	public static int bonusCountdown;
	public Sprite[] brickSprites;
	public AudioClip[] audioClipList;
	public GameObject smoke;
	public GameObject[] bonusList;

	private Ball ball;
	private LevelManager levelManager;
	private ParticleSystem.MainModule smokePuff;
	private int maxHits;
	private int timesHit;
	private float volume;



	void Start () {
		ballStrength = 1;
		bonusCountdown = 20;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
		maxHits = brickSprites.Length + 1;
		if (this.tag == "Breakable") {
			breakableCount++;
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		ball = GameObject.FindObjectOfType<Ball> ();
		if (this.tag == "Breakable") {
			PlaySound ();
			HandleHit ();
			print(bonusCountdown);
			BonusCheck();
		}
	}



	void PlaySound() {
		if (Mathf.Abs(ball.ballRigidBody.velocity.x) < Mathf.Abs(ball.ballRigidBody.velocity.y)) {
			volume = Mathf.Clamp(Mathf.Abs(ball.ballRigidBody.velocity.y / 10), 0.0f, 1.0f);
		} else {
			volume = Mathf.Clamp(Mathf.Abs(ball.ballRigidBody.velocity.x / 10), 0.0f, 1.0f);
		}
		AudioSource.PlayClipAtPoint (audioClipList [maxHits - timesHit - 1], this.transform.position, volume);
	}

	void HandleHit() {
		timesHit += ballStrength;
		if (timesHit >= maxHits) {
			smokePuff = Instantiate (smoke, this.transform.position, Quaternion.identity).GetComponent<ParticleSystem> ().main;
			smokePuff.startColor = this.GetComponent<SpriteRenderer> ().color;
			breakableCount--;
			bonusCountdown--;
			Destroy(gameObject);
			levelManager.Win ();
		} else {
			LoadSprite ();
		}
	}

	void LoadSprite() {
		int spriteIndex = timesHit - 1;
		if (brickSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = brickSprites [spriteIndex];
		}
	}

	public void BonusCheck() {
		if (bonusCountdown <= 0) {
				int randomIndex = Random.Range(0, (bonusList.Length));
				Instantiate (bonusList[randomIndex], transform.position, Quaternion.identity);
				bonusCountdown = 20;
		}
	}

}
