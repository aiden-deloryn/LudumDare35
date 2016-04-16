using UnityEngine;
using System.Collections;

public class DestroyerWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
		Destroy (other.gameObject);
	}
}
