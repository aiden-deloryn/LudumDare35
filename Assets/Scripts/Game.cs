using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public static Game instance;

	public float speed = .01f;
	public int pickupSpawnRate = 5;

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
		
	}
	
	// Update is called once per frame
	void Update () {
	
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
}