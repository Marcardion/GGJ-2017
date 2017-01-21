using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;
	public AudioSource musicSource;
	public static SoundManager instance = null;

	public float lowPitchRange = 0.95f;
	public float highPitchRange = 1.05f;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}
		
	void Start ()
	{
		StartCoroutine (PlayMusic (0.5f));
	}


	public void PlayMusic(AudioClip clip)
	{
		musicSource.clip = clip;
		musicSource.Play ();
	}

	public void PlaySingle (AudioClip clip) {
		efxSource.clip = clip;
		efxSource.Play();
	}

	public void RandomizeSfx (params AudioClip [] clips) {
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		efxSource.pitch = randomPitch;
		efxSource.clip = clips[randomIndex];
		efxSource.Play();
	}

	IEnumerator PlayMusic(float time)
	{
		yield return new WaitForSeconds (time);
		PlayMusic (musicSource.clip);
	}
}
