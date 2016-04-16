using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {
	public static Game instance;
	public bool running = true;

	public float speed = .001f;
	public int pickupSpawnRate = 10;
	private int score = 0;
	private int lives = 3;
	private float timeSinceLastTick = 0f;

	[SerializeField]
	Text scoreText;

	[SerializeField]
	Text livesText;

	[SerializeField]
	Sprite squareSprite;

	[SerializeField]
	Sprite circleSprite;

	[SerializeField]
	Sprite triangleSprite;

	[SerializeField]
	Sprite diamondSprite;

	[SerializeField]
	Sprite starSprite;

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Start() {
		AddScore (0);
		TakeLife (0);
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.timeSinceLevelLoad;
		if (currentTime - timeSinceLastTick > 1f) {
			speed += 0.001f;
			pickupSpawnRate += 1;
			timeSinceLastTick = currentTime;
		}
	}

	public Sprite SpriteForShape(Shape shape) {
		switch (shape) {
		case Shape.SQUARE:
			return squareSprite;
		case Shape.CIRCLE:
			return circleSprite;
		case Shape.TRIANGLE:
			return triangleSprite;
		case Shape.DIAMOND:
			return diamondSprite;
		case Shape.STAR:
			return starSprite;
		default:
			return new Sprite();
		}
	}

	public Color ColourForShape(Shape shape) {
		switch (shape) {
		case Shape.SQUARE:
			return Colour.RED;
		case Shape.CIRCLE:
			return Colour.GREEN;
		case Shape.TRIANGLE:
			return Colour.BLUE;
		case Shape.DIAMOND:
			return Colour.YELLOW;
		case Shape.STAR:
			return Colour.PURPLE;
		default:
			return new Color();
		}
	}

	public void AddScore(int value) {
		score += value;
		scoreText.text = "Score: " + score.ToString();
	}

	public void TakeLife(int value) {
		lives -= value;
		string livesTextValue = "";

		for (int i = 0; i < lives; i++) {
			livesTextValue += "*";
		}

		livesText.text = livesTextValue;

		if (lives <= 0) {
			livesText.text = "Game Over!";
			running = false;
		}
	}
}