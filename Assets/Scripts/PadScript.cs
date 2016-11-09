using UnityEngine;
using System.Collections;
using System;

public class PadScript : MonoBehaviour {
	public float multiplier = 1.0f;
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		Vector3 force = new Vector3 (horizontal, 0, 0);
		horizontal = Input.GetAxis ("Mouse X");
		force += new Vector3 (horizontal, 0, 0);
		if (force.sqrMagnitude > 1) {
			force = force.normalized * multiplier;
		} else {
			force *= multiplier;
		}
		rigidbody.AddForce (force);
	}
}
