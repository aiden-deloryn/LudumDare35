using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	string size = "LARGE";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 currentPos = gameObject.transform.position;
		float speed = Game.instance.speed;

		if (size == "LARGE")
			speed = speed / 2;

		if (size == "MEDIUM")
			speed = speed / 3;

		if (size == "SMALL")
			speed = speed / 4;

		gameObject.transform.position = new Vector3 (currentPos.x, currentPos.y + speed, currentPos.z);
	}

	public void SetSize(string size) {
		this.size = size;

		if (size == "LARGE") {
			transform.localScale = new Vector3 (0.2f, 0.2f, 1f);
		} else if (size == "MEDIUM") {
			transform.localScale = new Vector3 (0.15f, 0.15f, 1f);
		} else {
			transform.localScale = new Vector3 (0.1f, 0.1f, 1f);
		}
	}
}
