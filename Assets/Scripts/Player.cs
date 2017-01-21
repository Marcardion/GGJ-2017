using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	private Rigidbody2D pRigidbody;
	private Animator pAnimator;
	private bool hasKey = false;
	private float moveForce = 10;
	//private GameObject soundWave;

	// Use this for initialization
	void Start () {
		//soundWave = Resources.Load ("SoundWave") as GameObject;
		pRigidbody = gameObject.GetComponent<Rigidbody2D>();
		pAnimator = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float moveDirectionX = Input.GetAxisRaw("Horizontal");
		float moveDirectionY = Input.GetAxisRaw("Vertical");

		if(moveDirectionX != 0) {
			moveDirectionY = 0;
		}

		ChangePlayerDirection (moveDirectionX);

		pRigidbody.velocity = new Vector2(moveDirectionX*moveForce, moveDirectionY*moveForce);
	}

	void ChangePlayerDirection(float moveX) {
		if (moveX != 0) {
			transform.localScale = new Vector2 (moveX, transform.localScale.y);
		}
	}

	void KeyCollected() {
		hasKey = true;
		Debug.Log("Chave coletada");
	}

	void TryDoor(GameObject door) {
		Debug.Log("Trying Door");
		if(hasKey) {
			door.SendMessage("Open");
		}
	}
}



//protected IEnumerator SmoothMovement (Vector3 end)
//{
//	//Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
//	//Square magnitude is used instead of magnitude because it's computationally cheaper.
//	float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
//
//	//While that distance is greater than a very small amount (Epsilon, almost zero):
//	while(sqrRemainingDistance > float.Epsilon)
//	{
//		//Find a new position proportionally closer to the end, based on the moveTime
//		Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
//
//		//Call MovePosition on attached Rigidbody2D and move it to the calculated position.
//		rb2D.MovePosition (newPostion);
//
//		//Recalculate the remaining distance after moving.
//		sqrRemainingDistance = (transform.position - end).sqrMagnitude;
//
//		//Return and loop until sqrRemainingDistance is close enough to zero to end the function
//		yield return null;
//	}
//}