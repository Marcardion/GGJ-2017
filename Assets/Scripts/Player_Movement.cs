using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {


	private Rigidbody my_rigidbody;

	private Vector2 interp_axis;

	public float move_speed;

	// Use this for initialization
	void Start () {

		my_rigidbody = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		Move ();
	
	}

	void Move()
	{
		InterpolateAxis ();

		Vector3 move_vector = new Vector3(move_speed*interp_axis.x, my_rigidbody.velocity.y, move_speed*interp_axis.y);

		my_rigidbody.velocity = move_vector;
	}

	public void PlaceMove(Vector3 position)
	{
		transform.position = new Vector3(transform.position.x + position.x,transform.position.y + position.y,transform.position.z + position.z);
	}

	void InterpolateAxis()
	{
		interp_axis = Vector2.Lerp (interp_axis, new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")), Time.fixedDeltaTime*3f);
	}
}
