using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public AudioClip fireSound;
	public GameObject projectile;
	public float health;
	public float projectileSpeed;
	public float shotsPerSecondes;
	public int scoreValue;
	public AudioClip deathSound;

	private float randomRate;
	private ScoreKeeper scoreKeeper;


	void Start() {
		scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper> ();
	}

	void Update() {
		float probability = Time.deltaTime * shotsPerSecondes;
		if (Random.value < probability) {
			Fire ();
		}
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		Projectile missile = trigger.gameObject.GetComponent<Projectile> ();
		if (missile) {
			missile.Hit ();
			health -= missile.GetDamage ();
			if (health <= 0) {
				AudioSource.PlayClipAtPoint (deathSound, transform.position);
				Destroy (gameObject);
				scoreKeeper.Score(scoreValue);
			}
		}
	}

	void Fire() {
		GameObject missile  = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0.0f, -projectileSpeed);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}
}