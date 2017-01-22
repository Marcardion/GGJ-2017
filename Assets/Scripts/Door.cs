using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	public AudioClip open_door;
	public AudioClip closed_door;
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
			SoundManager.instance.PlaySingle (open_door);
			StartCoroutine (WaitDelay ());
		}
		//MakeNoise and go to next level
	}

	void Closed(){

		SoundManager.instance.PlaySingle (closed_door);
	
	}

	IEnumerator WaitDelay()
	{
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
