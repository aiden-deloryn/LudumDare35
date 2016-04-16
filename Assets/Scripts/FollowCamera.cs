using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	[SerializeField]
	GameObject target;

	[SerializeField]
	float followSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector3 positionThisFrame = Vector3.Lerp (transform.position, target.transform.position, followSpeed * Time.deltaTime);
			transform.position = new Vector3 (positionThisFrame.x, positionThisFrame.y, transform.position.z);
		}
	}
}
