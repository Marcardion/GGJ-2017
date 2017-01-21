using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	private GameObject player;
	private Vector3 maxScale = new Vector3(4,4,1);


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;

		PulseWave();
	}

	void PulseWave() {
		if((transform.localScale - maxScale).sqrMagnitude < 0.1){
			transform.localScale = Vector3.one;
		} else {
			transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.deltaTime);
		}
	}
}
