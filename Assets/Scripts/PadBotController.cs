using UnityEngine;
using System.Collections;

public class PadBotController : MonoBehaviour {
	public float multiplier = 1.0f;
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		if (ball) {
			if (ball.transform.position.x + ball.transform.localScale.x / 2 > transform.position.x + ball.transform.localScale.x / 2) {
				rigidbody.AddForce (new Vector3 (1, 0, 0) * multiplier);
			} else {
				rigidbody.AddForce (new Vector3 (-1, 0, 0) * multiplier);
			}
		}
	}
}
