using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStone : MonoBehaviour {

	private Defenders defenders;
	private Animator animator;

	void Start() {
		defenders = GetComponent<Defenders> ();
		animator = GetComponent<Animator> ();
	}

	void OnTriggerStay2D (Collider2D collider) {
		GameObject target = collider.gameObject;
		print ("Allo?");
		if (target.GetComponent<Attackers>()) {
			animator.SetTrigger ("underAttack trigger");
		}
	}
}