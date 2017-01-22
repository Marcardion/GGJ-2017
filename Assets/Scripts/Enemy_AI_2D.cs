using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_AI_2D : MonoBehaviour {

	private Transform target;
	public float move_speed = 0.5f;

	private Rigidbody2D my_rigidbody;

	Animator my_anim;

	private bool chase_player = false;

	private Vector3 start_pos;

	// Use this for initialization
	void Start () {
		my_rigidbody = GetComponent<Rigidbody2D> ();
		my_anim = GetComponent<Animator> ();
		start_pos = transform.position;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (chase_player) {
			Vector2 direction = target.position - transform.position;
			my_rigidbody.MovePosition (new Vector2 (transform.position.x, transform.position.y) + (direction.normalized * move_speed));
		} else 
		{
			Vector2 direction = start_pos - transform.position;
			my_rigidbody.MovePosition (new Vector2 (transform.position.x, transform.position.y) + (direction.normalized * move_speed));
		}
	}

	void  OnTriggerStay2D (Collider2D collider)
	{
		if (collider.CompareTag ("Player")) 
		{

			GameObject.FindGameObjectWithTag ("SoundWave").GetComponent<Wave> ().IncreaseHeartBeat ();
			Vector2 direction = target.position - transform.position;

			RaycastHit2D hit = Physics2D.Raycast (transform.position, direction);

				if (hit.collider.CompareTag ("Player")) 
				{
					chase_player = true;

				my_anim.SetBool ("Reveal", true);

				}
				else 
				{
					chase_player = false;

				my_anim.SetBool ("Reveal", false);
				}
				

		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			GameObject.FindGameObjectWithTag ("SoundWave").GetComponent<Wave> ().NormalizeHeartBeat ();
			chase_player = false;
			my_anim.SetBool ("Reveal", false);
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.CompareTag ("Player")) 
		{
			Debug.Log ("Attack");
			StartCoroutine (EndGame ());
		}
	}

	IEnumerator EndGame ()
	{
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
