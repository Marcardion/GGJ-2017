using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour {

	public AudioClip key_clip;

	private bool keyCollected = false;

	void OnTriggerEnter2D(Collider2D coll) {
		if(!keyCollected) {			
			if(coll.gameObject.tag=="Player") {	
				keyCollected = true;
				GetComponent<Animator> ().SetTrigger ("Disappear");
				SoundManager.instance.PlaySingle (key_clip);
				coll.SendMessage("KeyCollected");
			}
		}
	}
}
