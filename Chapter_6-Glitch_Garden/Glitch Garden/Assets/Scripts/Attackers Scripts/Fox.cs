using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attackers))]
public class Fox : MonoBehaviour {

	private Attackers attackers;
	private Animator animator;

	// Use this for initialization
	void Start () {
		attackers = GetComponent<Attackers> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject target = collider.gameObject;
		if (!target.GetComponent<Defenders>()) {
			return;
		} else if (target.GetComponent<GraveStone>()) {
			animator.SetTrigger ("Jump Trigger");
		} else {
			animator.SetBool ("isAttacking", true);
			attackers.Attack (target);
		}
	}
}
