using UnityEngine;
using System.Collections;
using System;

public class BallController : MonoBehaviour {
	public float initialForceMultiplier = 1;
	Rigidbody rigidbody;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		rigidbody = GetComponent<Rigidbody> ();
		Vector3 force = 
			Quaternion.Euler (0, UnityEngine.Random.Range (-60, 60), 0) * Vector3.forward;
		force = force * initialForceMultiplier;
		rigidbody.AddForce (force);
	}

	public void normalizeForce() {
		Vector3 force = rigidbody.velocity.normalized * initialForceMultiplier;
		rigidbody.velocity = Vector3.zero;
		rigidbody.AddForce (force);

	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.CompareTag ("Wall") || collision.gameObject.CompareTag ("Pad")) {
			audioSource.Play ();
		}
	}
}
