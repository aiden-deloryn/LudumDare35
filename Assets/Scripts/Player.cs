using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float movementSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}

	private void Move() {
		float horizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");
		Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		Vector2 velocity = new Vector2 (horizontalAxis * movementSpeed, verticalAxis * movementSpeed);

		rigidbody.velocity = velocity;
	}
}