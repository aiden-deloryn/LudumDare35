using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {
	[SerializeField]
	GameObject pickup;

	[SerializeField]
	Transform[] pickupSpawnPoints;

	float timeSinceLastTick = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Game.instance.running == false)
			return;
		
		float currentTime = Time.timeSinceLevelLoad;

		if (currentTime - timeSinceLastTick > 0.1f) {
			if (Random.Range (0, 1000) < Game.instance.pickupSpawnRate) {
				Vector3 spawnPoint = pickupSpawnPoints [Random.Range(0, pickupSpawnPoints.Length)].position;
				GameObject.Instantiate (pickup, spawnPoint, Quaternion.identity);
			}

			timeSinceLastTick = currentTime;
		}
	}
}
