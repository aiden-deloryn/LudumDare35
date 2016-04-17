using UnityEngine;
using System.Collections;

public class PlayerScoreAnimator : MonoBehaviour {
	Vector3 startScale;
	float targetScaleMultiplier = 1.5f;
	float speed = 0.08f;

	private float targetScale;
	private bool targetScaleReached = false;

	// Use this for initialization
	void Start () {
		startScale = gameObject.transform.localScale;
		targetScale = startScale.x * targetScaleMultiplier;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!targetScaleReached) {
			gameObject.transform.localScale += new Vector3 (speed, speed, 0f);
			if (gameObject.transform.localScale.x >= targetScale) {
				targetScaleReached = true;
			}
		} else {
			gameObject.transform.localScale -= new Vector3 (speed, speed, 0f);
			if (gameObject.transform.localScale.x <= startScale.x) {
				gameObject.transform.localScale = startScale;
				Destroy (this);
			}
		}
	}
}
