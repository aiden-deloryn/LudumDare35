using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	private SpriteRenderer spriteRenderer;

	private Shape shape;

	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		int randomNum = Random.Range (0, 5);

		switch (randomNum) {
		case 0:
			shape = Shape.SQUARE;
			break;
		case 1:
			shape = Shape.CIRCLE;
			break;
		case 2:
			shape = Shape.TRIANGLE;
			break;
		case 3:
			shape = Shape.DIAMOND;
			break;
		case 4:
			shape = Shape.STAR;
			break;
		}

		spriteRenderer.sprite = Game.instance.SpriteForShape (shape);
		spriteRenderer.color = Game.instance.ColourForShape (shape);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 currentPos = gameObject.transform.position;
		gameObject.transform.position = new Vector3 (currentPos.x, currentPos.y + Game.instance.speed, currentPos.z);
	}
}
