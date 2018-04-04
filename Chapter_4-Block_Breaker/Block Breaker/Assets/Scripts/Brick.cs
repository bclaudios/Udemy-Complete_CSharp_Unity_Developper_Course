using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public int timesHit;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;

	private bool isBreakable;
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		print (breakableCount);
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		bool isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		AudioSource.PlayClipAtPoint (crack, transform.position);
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			Destroy(gameObject);
			breakableCount--;
			levelManager.BrickDestroyed ();
		} else {
			LoadSprites ();
		}
	}

	//TODO Remove this methis once we can actually win!
}
