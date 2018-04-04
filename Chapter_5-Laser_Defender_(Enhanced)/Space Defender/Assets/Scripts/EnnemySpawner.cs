using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour {

	public float width, height;
	public float yMovement;
	public float movementDelay;

	public GameObject[] ennemyList;
	public float formationSpawnDelay;

	public AudioClip toneSFX;
	public float SFXToneVolume;
	public float SFXToneDelay;


	private float xMin, xMax;
	private bool movingRight = false;
	private GameObject nextEnemy;
	private AudioSource audio;




	void Start() {
		SpawnEnnemy ();
		PlayToneSound ();
	}

	void Update() {
		StartCoroutine("MovementDelay");
		if (AllEnnemiesAreDead()) {
			StartCoroutine("FormationSpawnDelay");
		}
	}




	void SpawnEnnemy() {
		Transform nextFreePosition = NextFreePosition ();
		if (nextFreePosition) {
			if (nextFreePosition.tag == "T1") {
				nextEnemy = ennemyList [0];
			} else if (nextFreePosition.tag == "T2") {
				nextEnemy = ennemyList [1];
			} else if (nextFreePosition.tag == "T3") {
				nextEnemy = ennemyList [2];
			} else if (nextFreePosition.tag == "T4") {
				nextEnemy = ennemyList [3];
			}
			GameObject ennemy = Instantiate (nextEnemy, nextFreePosition.position, Quaternion.identity) as GameObject;
			ennemy.transform.parent = nextFreePosition;
		}
		if (NextFreePosition()) {
			SpawnEnnemy();
		}
	}

	Transform NextFreePosition() {
		foreach (Transform child in transform) {
			if (child.childCount == 0) {
				return child;
			}
		}
		return null;
	}




	IEnumerator MovementDelay() {
		yield return new WaitForSeconds(movementDelay);
		FormationMovement();
	}

	void FormationMovement(){
		transform.position += new Vector3 (0f, yMovement) * Time.deltaTime;
	}


	bool AllEnnemiesAreDead() {
		foreach (Transform child in transform) {
			if (child.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	IEnumerator FormationSpawnDelay() {
		audio.Stop();
		yield return new WaitForSeconds(formationSpawnDelay);
		Destroy (gameObject);
	}




	void PlayToneSound() {
		audio = GetComponent<AudioSource> ();
		audio.clip = toneSFX;
		audio.loop = true;
		audio.volume = SFXToneVolume;
		audio.PlayDelayed (SFXToneDelay);
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
}
