using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAutoDestroy : MonoBehaviour {

	private LevelManager levelManager;




	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		if (gameObject.tag == "playerExplosion") {
			Invoke ("LoseScreen", this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length);
		} else {
			Destroy (gameObject, this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length);
		}
	}




	void LoseScreen() {
		levelManager.LoadScene("Lose Screen");
	}
}
