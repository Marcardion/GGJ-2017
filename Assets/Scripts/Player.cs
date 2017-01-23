using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	private Rigidbody2D pRigidbody;
	private bool hasKey;
	private float moveForce = 15;
	private bool controllerEnabled;

	// Use this for initialization
	void Start () {
		pRigidbody = gameObject.GetComponent<Rigidbody2D>();
		controllerEnabled = true;
		hasKey = false;
	}
	
	// Update is called once per frame
	void Update () {

		float moveDirectionX = Input.GetAxisRaw("Horizontal");
		float moveDirectionY = Input.GetAxisRaw("Vertical");

		if(controllerEnabled) {
			ChangePlayerDirection (moveDirectionX);
			pRigidbody.velocity = new Vector2(moveDirectionX*moveForce, moveDirectionY*moveForce);
		}
	}

	void ChangePlayerDirection(float moveDirection) {
		//moveDirection 1 = right / -1 = left
		if (moveDirection != 0) {
			transform.localScale = new Vector2 (Mathf.Abs(transform.localScale.x)*moveDirection, transform.localScale.y);
		}
	}

	bool PlayerIsMoving() {
		if (Mathf.Abs (pRigidbody.velocity.x) > 0.1 || Mathf.Abs (pRigidbody.velocity.y) > 0.1) {
			return true;
		}
		return false;				
	}

	void KeyCollected() {
		hasKey = true;
		Debug.Log("Chave coletada");
	}

	void TryDoor(GameObject door) {
		Debug.Log("Trying Door");
		if (hasKey) {
			controllerEnabled = false;
			door.SendMessage ("Open");
		} else {
			door.SendMessage ("Closed");
		}
	}
}