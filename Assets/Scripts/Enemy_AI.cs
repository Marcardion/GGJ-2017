using System.Collections;
using System.Collections.Generic;
using UnityEngine;	
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour {

	public Transform target;
	public Vector3 start_pos;

	NavMeshAgent agent;

	public bool move = false;

	// Use this for initialization
	void Start () {

		agent = GetComponent<NavMeshAgent> ();
		agent.updateRotation = false;

		start_pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 direction = target.position - transform.position;

		Debug.DrawRay (transform.position, direction, Color.black);

		if (move) {
			agent.SetDestination (target.position);
		} else {
			agent.SetDestination (start_pos);
		}

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
					move = true;
				}
				else 
				{
					move = false;
				}

			}

		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			move = false;
		}
	}
}
