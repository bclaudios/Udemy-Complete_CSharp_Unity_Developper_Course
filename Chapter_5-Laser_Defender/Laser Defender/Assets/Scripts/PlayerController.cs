using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public AudioClip fireSound;
	public GameObject playerLaser;
	public float speed;
	public float padding;
	public float projectileSpeed;
	public float firingRate;
	public float playerHealth;

	private float newX, xMin, xMax;
	private Rigidbody2D laserRB;

	void Start() {
		EdgesDefinition ();
	}

	void Update () {
		InputMovement ();
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, firingRate);
		} else if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke();
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			missile.Hit ();
			playerHealth -= missile.GetDamage ();
			if (playerHealth <= 0) {
				Die ();
			}
		}
	}

	void Die() {
		LevelManager levelManager = GameObject.FindObjectOfType<LevelManager> ();
		Destroy (gameObject);
		levelManager.LoadScene ("LoseScreen");
	}

	void EdgesDefinition() {
		float zDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, zDistance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, zDistance));
		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
	}

	void InputMovement () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}

	void Fire() {
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
		GameObject laser = Instantiate (playerLaser, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, projectileSpeed);
	}
}
