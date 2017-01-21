using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	private GameObject player;
	private float maxScaleFactor = 25;
	private Vector3 maxScale;

	private float fade_out = 1;
	private bool on_fade = false;

	SpriteRenderer my_render;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		maxScale = new Vector3 (maxScaleFactor, maxScaleFactor, 1);
		my_render = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;

		PulseWave();
	}

	void PulseWave() {
		if((transform.localScale - maxScale).sqrMagnitude < 0.2){
			if (on_fade == false) 
			{
				StartCoroutine (Fade ());
				on_fade = true;
			}
		} else {
			transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.deltaTime*1.2f);
		}
	}

	IEnumerator Fade()
	{
		while (fade_out > 0) 
		{
			my_render.color = new Color (my_render.color.r, my_render.color.g, my_render.color.b, fade_out);
			fade_out = fade_out - Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}

		transform.localScale = Vector3.one;
		fade_out = 1;
		my_render.color = new Color (my_render.color.r, my_render.color.g, my_render.color.b, fade_out);
		on_fade = false;
	}


}
