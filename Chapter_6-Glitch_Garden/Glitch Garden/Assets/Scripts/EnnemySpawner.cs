using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour {

	public GameObject[] attackersArray;

	// Update is called once per frame
	void Update () {
		foreach (GameObject myAttacker in attackersArray){
			if (isTimeToSpawn(myAttacker)) {
				Spawn (myAttacker);
			}
		}
	}

	public void Spawn (GameObject myGameObject) {
		GameObject newAttacker = Instantiate (myGameObject, transform.position, Quaternion.identity) as GameObject;
		newAttacker.transform.parent = transform;
	}

	bool isTimeToSpawn (GameObject attackerGameObject) {
		Attackers attacker = attackerGameObject.GetComponent<Attackers> (); //Récuperation du script de l'objet a faire spawn
		float meanSpawnDelay = attacker.seenEverySeconds; //Récuperation de la variable public du script Attacker (Seen Every X Seconds, un mob spawn toute les X secondes)
		float spawnPerSeconds = 1 / meanSpawnDelay; //Combien de fois un mob spawn par secondes. Donc 1 (une seconde) divisé par le delai de spawn recup juste au dessus (exemple : 1 / 5 donc un mob toute les 5 secondes = 0.2)
		if (spawnPerSeconds < Time.deltaTime) { 
			Debug.LogWarning ("Spawn rate capped by framerate"); //Message d'erreur si les mob spawn plus vite que le framerate
		}
		float threshold = spawnPerSeconds * Time.deltaTime / 5;//Normalisation du spawnPerSeconds par rapport au framerate, divisé par 5 car 5 spawner different
		return (Random.value < threshold);  
	}
}
