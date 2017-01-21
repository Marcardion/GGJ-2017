using System.Collections;
using System.Collections.Generic;
using UnityEngine;	
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_AI : MonoBehaviour {

	public enum Enemy_Type { Guard, Patrol };

	public Enemy_Type my_type;

	public Transform target;

	public Vector3 start_pos;

	public Vector3[] patrol_list;
	private int patrol_index = 0;

	NavMeshAgent agent;

	public bool chase_player = false;

	// Use this for initialization
	void Start () {

		agent = GetComponent<NavMeshAgent> ();
		agent.updateRotation = false;

		start_pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		if (chase_player) {
			agent.SetDestination (target.position);
		} else {
			if (my_type == Enemy_Type.Guard) {
				agent.SetDestination (start_pos);
			} else if (my_type == Enemy_Type.Patrol) 
			{
				Patrol ();
			}
		}

	}

	void Patrol ()
	{
		if (Vector3.Distance (transform.position, patrol_list [patrol_index]) < 1) 
		{
			patrol_index++;
			if(patrol_index >= patrol_list.Length)
			{
				patrol_index = 0;
			}
		}

		agent.SetDestination (patrol_list [patrol_index]);
	}

	void  OnTriggerStay (Collider collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			RaycastHit hit;

			Vector3 direction = target.position - transform.position;
		
			if (Physics.Raycast (transform.position, direction, out hit)) 
			{
				
				if (hit.collider.CompareTag ("Player")) 
				{
					chase_player = true;
				}
				else 
				{
					chase_player = false;
				}

			}

		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			chase_player = false;
		}
	}

	void OnCollisionEnter (Collision collision)
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
