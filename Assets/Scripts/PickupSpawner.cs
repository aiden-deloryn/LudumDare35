using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {
	[SerializeField]
	GameObject pickup;

	float timeSinceLastTick = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.timeSinceLevelLoad;

		if (currentTime - timeSinceLastTick > 0.5f) {
			if (Random.Range (0, 1000) < Game.instance.pickupSpawnRate) {
				GameObject.Instantiate (pickup, gameObject.transform.position, Quaternion.identity);
			}

			timeSinceLastTick = currentTime;
		}
	}
}
