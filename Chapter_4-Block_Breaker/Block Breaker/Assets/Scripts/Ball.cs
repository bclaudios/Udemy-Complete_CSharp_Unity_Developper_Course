using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		print (this.GetComponent<Rigidbody2D> ().velocity);
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (Random.Range(-4f, 4f), 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range (-0.2f, 0.2f), Random.Range (-0.2f, 0.2f));
		if (hasStarted) {
			audioSource.Play ();
			this.GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
