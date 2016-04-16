using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField]
	float movementSpeed = 5f;

	[SerializeField]
	SpriteRenderer spriteRenderer;

	private Shape currentShape;

	// Use this for initialization
	void Start () {
		ShapeShift (Shape.SQUARE);
	}

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			if (currentShape == Shape.STAR) {
				ShapeShift (Shape.SQUARE);
			} else {
				ShapeShift (currentShape + 1);
			}
		} else if (Input.GetButtonDown("Fire2")) {
			if (currentShape == Shape.SQUARE) {
				ShapeShift (Shape.STAR);
			} else {
				ShapeShift (currentShape - 1);
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}

	private void Move() {
		float horizontalAxis = Input.GetAxis ("Horizontal");
//		float verticalAxis = Input.GetAxis ("Vertical");
		Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		Vector2 velocity = new Vector2 (horizontalAxis * movementSpeed, 0f);

		rigidbody.velocity = velocity;
	}

	void ShapeShift(Shape newShape) {
		currentShape = newShape;
		spriteRenderer.sprite = Game.instance.SpriteForShape (newShape);
		spriteRenderer.color = Game.instance.ColourForShape (newShape);
	}
}