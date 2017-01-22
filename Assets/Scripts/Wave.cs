using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	private GameObject player;
	private float maxScaleFactor = 25;
	private Vector3 maxScale;
	public AudioClip heart_sound;

	private float heartbeat_speed = 1;

	private float fade_out = 1;
	private bool on_fade = false;
	private bool play_heartbeat = true;

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
			if (play_heartbeat) 
			{
				SoundManager.instance.PlaySingle (heart_sound);
				play_heartbeat = false;
			}
			transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.deltaTime*2.2f*heartbeat_speed);

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

		fade_out = 1;
		my_render.color = new Color (my_render.color.r, my_render.color.g, my_render.color.b, fade_out);
		transform.localScale = Vector3.one;
		on_fade = false;
		play_heartbeat = true;
	}

	public void IncreaseHeartBeat ()
	{
		heartbeat_speed = 10f;
	}

	public void NormalizeHeartBeat ()
	{
		heartbeat_speed = 1f;
	}
}
