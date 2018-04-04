using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour {

	private Defenders defenders;
	private Animator animator;

	void Start() {
		defenders = GetComponent<Defenders> ();
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject target = collider.gameObject;
		if (target.GetComponent<Attackers>()) {
			animator.SetBool ("isAttacking", true);
		}
	}
}