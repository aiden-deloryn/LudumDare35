using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	[SerializeField]
	GameObject debrisParticle;

	public Color colour = new Color (1, 1, 1);

	int numberOfParticles = 100;
	float randomPositionOffset = 0.1f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfParticles; i++) {
			float randomPosX = Random.Range(transform.position.x - randomPositionOffset, transform.position.x + randomPositionOffset);
			float randomPosy = Random.Range(transform.position.y - randomPositionOffset, transform.position.y + randomPositionOffset);
			Vector3 position = new Vector3 (randomPosX, randomPosy, transform.position.z);

			debrisParticle.GetComponent<SpriteRenderer> ().color = colour;
			GameObject particle = GameObject.Instantiate (debrisParticle, position, Quaternion.identity) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
