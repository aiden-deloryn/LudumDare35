using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField]
	float movementSpeed = 10f;

	[SerializeField]
	SpriteRenderer spriteRenderer;

	private Shape currentShape;

	// Use this for initialization
	void Start () {
		ShapeShift (Shape.SQUARE);
	}

	void Update() {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}

	public void OnTriggerStay2D(Collider2D other) {
		Pickup pickup = other.gameObject.GetComponent<Pickup>();

		if (pickup == null)
			return;
		
		if (currentShape == pickup.GetShape ()) {
			Game.instance.AddScore(10);
			ShapeShift ();
		} else {
			Game.instance.TakeLife (1);
		}

		Destroy (other.gameObject);
	}

	private void Move() {
		float horizontalAxis = Input.GetAxis ("Horizontal");
//		float verticalAxis = Input.GetAxis ("Vertical");
		Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		Vector2 velocity = new Vector2 (horizontalAxis * movementSpeed, 0f);

		rigidbody.velocity = velocity;
	}

	void ShapeShift() {
		int randomNum = Random.Range (0, 5);
		Shape randomShape;

		switch (randomNum) {
		case 0:
			randomShape = Shape.SQUARE;
			break;
		case 1:
			randomShape = Shape.CIRCLE;
			break;
		case 2:
			randomShape = Shape.TRIANGLE;
			break;
		case 3:
			randomShape = Shape.DIAMOND;
			break;
		case 4:
			randomShape = Shape.STAR;
			break;
		default:
			randomShape = Shape.SQUARE;
			break;
		}

		ShapeShift (randomShape);
	}

	void ShapeShift(Shape newShape) {
		currentShape = newShape;
		spriteRenderer.sprite = Game.instance.SpriteForShape (newShape);
		spriteRenderer.color = Game.instance.ColourForShape (newShape);
	}
}