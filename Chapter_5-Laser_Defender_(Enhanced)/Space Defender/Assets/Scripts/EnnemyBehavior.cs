using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehavior : MonoBehaviour {

	public float ennemyHealth;

	public GameObject projectile;
	public float firingSpeed, projectileSpeed;
	public float minFiringRate, maxFiringRate;
	public int minShotNumber, maxShotNumber;
	public int score;

	public float spriteRedTime;
	public float spriteWhiteDelay;

	public AudioClip[] arrivalSFXList;
	public float SFXArrivalVolume;

	public AudioClip[] explosionSFXList;
	public float SFXExplosionVolume;

	public GameObject explosionSprites;


	private float firingRate;
	private bool rightCanon;
	private int shotFired;
	private int shotNumber;
	private int randomFirstShotDelay;
	private Score scoreKeeper;
	private AudioSource audio;
	private GameObject laser;




	void Start() {
		audio = GetComponent<AudioSource> ();
		scoreKeeper = FindObjectOfType<Score>();
		randomFirstShotDelay = Random.Range (1, 4);
		firingRate = Random.Range(minFiringRate, maxFiringRate);
		rightCanon = true;
		PlayArrivalSound ();
		Invoke ("FireRepartition", randomFirstShotDelay);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.tag != "Shredder") {
			ennemyHealth--;
			if (ennemyHealth <= 0) {
				scoreKeeper.AddScore (score);
				EnnemyDeath ();
			} else {
				StartCoroutine (HitColor ());
			}
		}
	}




	void PlayArrivalSound() {
		int randomSoundIndex = Random.Range (0, arrivalSFXList.Length);
		audio.clip = arrivalSFXList [randomSoundIndex];
		audio.volume = SFXArrivalVolume;
		audio.Play ();
	}




	void FireRepartition() {
		if (tag == "Level 1") {
			InvokeRepeating ("FireLvl1", 0.00001f, firingRate);
		} else if (tag == "Level 2") {
			InvokeRepeating ("FireLvl2", 0.00001f, firingRate);
		} else if (tag == "Level 3") {
			InvokeRepeating ("FireLvl3", 0.00001f, firingRate);
		}
	}


	void FireLvl1 () {
		shotFired = 0;
		shotNumber = Random.Range (minShotNumber, maxShotNumber);
		InvokeRepeating ("ShotLvl1", 0.00001f, firingSpeed);
	}

	void ShotLvl1 () {
		laser = Instantiate (projectile, transform.position, Quaternion.identity);
		laser.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -projectileSpeed, 0);
		shotFired++;
		if (shotFired >= shotNumber) {
			CancelInvoke("ShotLvl1");
		}
	}


	void FireLvl2() {
		shotFired = 0;
		shotNumber = Random.Range (minShotNumber, maxShotNumber);
		InvokeRepeating ("ShotLvl2", 0.00001f, firingSpeed);
	}

	void ShotLvl2() {
		Vector3 laserPadding = new Vector3 (0.15f, 0);
		GameObject leftLaser = Instantiate (projectile, (transform.position - laserPadding), Quaternion.identity);
		GameObject rightLaser = Instantiate (projectile, (transform.position + laserPadding), Quaternion.identity);
		leftLaser.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -projectileSpeed, 0);
		rightLaser.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -projectileSpeed, 0);
		shotFired++;
		if (shotFired >= shotNumber) {
			CancelInvoke("ShotLvl2");
		}
	}


	void FireLvl3() {
		shotFired = 0;
		shotNumber = Random.Range (minShotNumber, maxShotNumber);
		InvokeRepeating ("ShotLvl3", 0.00001f, firingSpeed);
	}

	void ShotLvl3 () {
		Vector3 laserPadding = new Vector3 (0.22f, 0);
		if (!rightCanon) {
			laser = Instantiate (projectile, (transform.position - laserPadding), Quaternion.identity) as GameObject;
			rightCanon = true;
		} else if (rightCanon) {
			laser = Instantiate (projectile, (transform.position + laserPadding), Quaternion.identity) as GameObject;
			rightCanon = false;
		}
		laser.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -projectileSpeed, 0);
		shotFired++;
		if (shotFired >= shotNumber) {
			CancelInvoke ("ShotLvl3");
		}
	}




	void EnnemyDeath() {
		int randomIndex = Random.Range (0, explosionSFXList.Length);
		AudioSource.PlayClipAtPoint (explosionSFXList [randomIndex], transform.position, SFXExplosionVolume);
		Instantiate (explosionSprites, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}


	IEnumerator HitColor() {
		SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color (255f, 0f, 0f, 255f);
		yield return new WaitForSeconds(spriteRedTime);
		spriteRenderer.color = new Color (255f, 255f, 255f, 255f);
	}
}