using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour {

	private bool keyCollected = false;

	void OnTriggerEnter2D(Collider2D coll) {
		if(!keyCollected) {			
			if(coll.gameObject.tag=="Player") {	
				keyCollected = true;
				GetComponent<Animator> ().SetTrigger ("Disappear");
				coll.SendMessage("KeyCollected");
			}
		}
	}
}
