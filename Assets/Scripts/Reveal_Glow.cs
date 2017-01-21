using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reveal_Glow : MonoBehaviour {


	Animator my_anim;

	// Use this for initialization
	void Start () {

		my_anim = GetComponent<Animator> ();
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.CompareTag ("SoundWave")) 
		{
			my_anim.SetTrigger ("Reveal");
		}
	}
}
