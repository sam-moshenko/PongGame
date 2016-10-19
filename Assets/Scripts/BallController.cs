using UnityEngine;
using System.Collections;
using System;

public class BallController : MonoBehaviour {
	public int initialForceMultiplier = 1;
	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		Vector3 force = new Vector3 (1, 0, 1) * initialForceMultiplier;
		rigidbody.AddForce (force);
	}
}
