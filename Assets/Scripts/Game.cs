using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {
	public static Game instance;
	public bool running = false;
	public float speed = .05f;
	public int pickupSpawnRate = 50;

	private AudioSource audioSource;
	private int score = 0;
	private int lives = 5;
	private float timeSinceLastTick = 0f;

	[SerializeField]
	Text scoreText;

	[SerializeField]
	Text livesText;

	[SerializeField]
	Text replayText;

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

	[SerializeField]
	GameObject backgrounStar;

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Start() {
		audioSource = gameObject.GetComponent<AudioSource> ();
		AddScore (0);
		TakeLife (0);
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.timeSinceLevelLoad;
		if (currentTime - timeSinceLastTick > 0.5f) {
			if (running) {
				speed += 0.001f;
				pickupSpawnRate += 2;
			}

			SpawnStar ();
			timeSinceLastTick = currentTime;
		}

		if (!running && Input.GetKeyDown (KeyCode.Space)) {
			running = true;
			speed = 0.05f;
			pickupSpawnRate = 50;
			score = 0;
			lives = 5; 
			AddScore (0);
			TakeLife (0);
			replayText.enabled = false;
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

		if (lives <= 0 && running) {
			livesText.text = "Game Over!";
			replayText.enabled = true;
			running = false;
			audioSource.Play ();
		}
	}

	public void SpawnStar() {
		Vector3 position = new Vector3(Random.Range(-6f, 6f), -10f, 0f);
		GameObject star = (GameObject.Instantiate (backgrounStar, position, Quaternion.identity) as GameObject);

		int randomNum = Random.Range (0, 3);

		if (randomNum == 0) {
			star.GetComponent<Star>().SetSize ("SMALL");
		} else if (randomNum == 1) {
			star.GetComponent<Star>().SetSize ("MEDIUM");
		} else {
			star.GetComponent<Star>().SetSize ("LARGE");
		}
	}
}