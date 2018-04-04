using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	private Text text;
	private PlayerController player;




	void Start () {
		player = GameObject.FindObjectOfType<PlayerController>();
		text = GetComponent<Text>();
	}

	void Update ()
	{
		if (gameObject.name == "Health") {
			text.text =	player.playerHealth.ToString ();
		} else if (gameObject.name == "Shield Remaining") {
			text.text = player.shieldCount.ToString();
		}
	}
}
