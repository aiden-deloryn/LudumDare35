using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	[SerializeField]
	int roomSize = 10;

	[SerializeField]
	int tileSize = 2;

	[SerializeField]
	int obstacleLikelihood = 10;

	[SerializeField]
	GameObject[] wallTiles;

	[SerializeField]
	GameObject[] floorTiles;

	[SerializeField]
	GameObject[] obstacles;

	// Use this for initialization
	void Start () {
		GenerateRoom ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void GenerateRoom() {
		for (int row = 0; row < roomSize; row++) {
			for (int column = 0; column < roomSize; column++) {
				GameObject tile;

				if (row == 0 || column == 0 || row == roomSize - 1 || column == roomSize - 1) {
					tile = wallTiles [0];
				} else {
					if (Random.Range (1, 101) <= obstacleLikelihood) {
						tile = obstacles [0];
					} else {
						tile = floorTiles [0];
					}

				}

				Vector3 tilePosition = new Vector3 (column * tileSize, row * tileSize);

				GameObject.Instantiate (tile, tilePosition, Quaternion.identity);
			}
		}
	}
}
