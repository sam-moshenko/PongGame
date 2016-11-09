using UnityEngine;
using System.Collections;

public class PadCollisionController : MonoBehaviour {
	public int collisionAngleMultiplier = 1;

	void OnCollisionEnter(Collision collision) {
		GameObject gameObject = collision.gameObject;
		if (gameObject.CompareTag ("Ball")) {
			GameObject ball = gameObject;
			BallController ballController = ball.GetComponent<BallController> ();
			float shift = ball.transform.position.x - transform.position.x;
			Vector3 force = new Vector3 (1, 0, 0) * shift * collisionAngleMultiplier;
			ball.GetComponent<Rigidbody> ().AddForce (force);
			ballController.normalizeForce ();
		}
	}
}
