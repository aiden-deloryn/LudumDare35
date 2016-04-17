using UnityEngine;
using System.Collections;

public class DebrisParticle : MonoBehaviour {
	float maxOffsetX = 0.2f;
	float maxOffsetY = 0.2f;

	private float xOffset;
	private float yOffset;

	// Use this for initialization
	void Start () {
		xOffset = Random.Range (maxOffsetX * -1, maxOffsetX);
		yOffset = Random.Range (Game.instance.speed - maxOffsetY, Game.instance.speed + maxOffsetY);
		Destroy (this.gameObject, 3f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float newPosY = transform.position.y + yOffset;
		float newPosX = transform.position.x + xOffset;
		transform.position = new Vector3 (newPosX, newPosY);
	}
}
