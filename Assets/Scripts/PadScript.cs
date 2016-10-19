using UnityEngine;
using System.Collections;
using System;

public class PadScript : MonoBehaviour {
	public float multiplier = 1.0f;
	public int collisionAngleMultiplier = 1;
	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		Vector3 force = new Vector3 (horizontal, 0, 0) * multiplier;
		rigidbody.AddForce (force);
	}



	void OnCollisionEnter(Collision collision) {
		GameObject gameObject = collision.gameObject;
		if (gameObject.CompareTag ("Ball")) {
			GameObject ball = gameObject;
			BallController ballController = ball.GetComponent<BallController> ();
			float shift = ball.transform.position.x - transform.position.x;
			Vector3 force = new Vector3 (1, 0, 0) * shift * collisionAngleMultiplier;
			ball.GetComponent<Rigidbody> ().AddForce (force);
		}
	}

	/*
	Vector3 normalizeForce(Vector3 force, BallController forBall) {
		float multiplier = forBall.initialForceMultiplier / (force.x + force.z);
		print (String.Format ("Speed is {0}, and multiplier is {1}", force, multiplier));
		return force * multiplier;
	}
	*/
}
