using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField]
	float movementSpeed = 10f;

	[SerializeField]
	SpriteRenderer spriteRenderer;

	[SerializeField]
	GameObject explosion;

	[SerializeField]
	AudioClip explosionSound;

	[SerializeField]
	AudioClip scoreSound;

	private Shape currentShape;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
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
			if (!Game.instance.running)
				return;

			PlaySound (scoreSound);
			gameObject.AddComponent<PlayerScoreAnimator> ();
			Game.instance.AddScore(10);
			ShapeShift ();
		} else {
			PlaySound (explosionSound);
			Game.instance.TakeLife (1);
			explosion.GetComponent<Explosion> ().colour = Game.instance.ColourForShape (pickup.GetShape ());
			GameObject.Instantiate (explosion, other.gameObject.transform.position, Quaternion.identity);
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

	void PlaySound(AudioClip sound) {
		audioSource.clip = sound;
		audioSource.Play();
	}
}