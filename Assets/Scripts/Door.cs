using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	private bool doorOpened = false;

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag=="Player") {
			coll.gameObject.SendMessage("TryDoor", this.gameObject);
		}
	}

	void Open() {
		if(!doorOpened) {
			doorOpened = true;
			Debug.Log("Door Opened!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		//MakeNoise and go to next level
	}
}
