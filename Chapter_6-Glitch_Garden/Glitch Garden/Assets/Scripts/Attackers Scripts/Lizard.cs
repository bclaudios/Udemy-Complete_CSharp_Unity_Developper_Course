using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attackers))]
public class Lizard : MonoBehaviour {

	private Attackers attackers;
	private Animator animator;

	// Use this for initialization
	void Start () {
		attackers = GetComponent<Attackers> ();
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject target = collider.gameObject;
		if (!target.GetComponent<Defenders>()) {
			return;
		} else {
			animator.SetBool ("isAttacking", true);
			attackers.Attack (target);
		}
	}
}
