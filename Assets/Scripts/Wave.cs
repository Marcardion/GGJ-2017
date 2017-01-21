using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	private GameObject player;
	private float maxScaleFactor = 25;
	private Vector3 maxScale;
	public AudioClip heart_sound;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		maxScale = new Vector3 (maxScaleFactor, maxScaleFactor, 1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 2);

		PulseWave();
	}

	void PulseWave() {
		if((transform.localScale - maxScale).sqrMagnitude < 0.2){
			transform.localScale = Vector3.one;
			SoundManager.instance.PlaySingle (heart_sound);

		} else {
			transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.deltaTime*2.2f);

		}
	}
}
