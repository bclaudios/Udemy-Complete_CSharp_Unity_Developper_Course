using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {


	public float bonusSpeed;

	private Ball ball;
	private Brick brick;



	void Start() {
		ball = GameObject.FindObjectOfType<Ball> ();
		brick = GameObject.FindObjectOfType<Brick>();
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -bonusSpeed);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (gameObject.tag == "BonusUpSpeed") {
			ball.UpSpeedBonus ();
		} else if (gameObject.tag == "BonusDownSpeed") {
			ball.DownSpeedBonus();
		} else if (gameObject.tag == "BonusMultiBall") {
			ball.MultiBallBonus();
		} else if (gameObject.tag == "BonusStrength") {
			ball.LaunchStrengthBonus();
		}
		Destroy (gameObject);
	}
}
