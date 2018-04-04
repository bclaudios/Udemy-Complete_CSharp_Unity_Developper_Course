using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public AudioClip[] shotSFXList;
	public float SFXShotVolume;

	public AudioClip[] impactSFXList;
	public float SFXImpactVolume;

	public AudioClip[] shieldImpactSFXList;
	public float SFXShielImpactVolume;

	public GameObject[] explosionAnimation;


	private int randomIndex;
	private PlayerController player;



	void Start() {
		player = GameObject.FindObjectOfType<PlayerController>();
		PlayShotSound ();
	}


	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.tag != "Shredder") {
			if (collider.gameObject.tag == "Shield") {
				randomIndex = Random.Range (0, shieldImpactSFXList.Length);
				AudioSource.PlayClipAtPoint (shieldImpactSFXList [randomIndex], transform.position, SFXShielImpactVolume);
				player.shieldHealth--;
			} else {
				randomIndex = Random.Range (0, explosionAnimation.Length);
				GameObject spark = Instantiate (explosionAnimation [randomIndex], transform.position, Quaternion.identity);
				randomIndex = Random.Range (0, impactSFXList.Length);
				AudioSource.PlayClipAtPoint (impactSFXList [randomIndex], transform.position, SFXImpactVolume);
			}
		}
		Destroy (gameObject);
	}




	void PlayShotSound() {
		int randomIndex = Random.Range (0, shotSFXList.Length);
		AudioSource.PlayClipAtPoint (shotSFXList [randomIndex], transform.position, SFXShotVolume);
	}
}
