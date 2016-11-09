using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject ballTemplate;
	public int maxScore = 11;

	public Text firstPlayerScoreText;
	public Text secondPlayerScoreText;
	public Text txtWinLoose;
	public AudioSource audioSource;

	private int firstPlayerScoreCount;
	private int secondPlayerScoreCount;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerExit(Collider other) {
		print ("OnTriggerExit with object" + other.gameObject.tag);
		if (other.gameObject.CompareTag ("Ball")) {
			print ("OnTriggerExit if statement");
			GameObject ball = other.gameObject;

			audioSource.Play ();

			float newBallDirection = 1;

			if (ball.transform.position.z < transform.position.z) {
				firstPlayerScoreCount++;
				firstPlayerScoreText.text = firstPlayerScoreCount.ToString();
			} else {
				newBallDirection = -1;
				secondPlayerScoreCount++;
				secondPlayerScoreText.text = secondPlayerScoreCount.ToString();
			}

			if (firstPlayerScoreCount == maxScore || secondPlayerScoreCount == maxScore) {
				StartCoroutine (GameOver ());
				return;
			}

			Destroy (ball);
			BallController newBall = Instantiate (ballTemplate).GetComponent<BallController> ();
			newBall.initialForceMultiplier = Mathf.Abs (newBall.initialForceMultiplier) * newBallDirection;
		}
	}

	public IEnumerator GameOver () {
		Destroy (GameObject.FindGameObjectWithTag ("Ball"));

		Color winLooseColor = new Color (1, 0, 0);
		if (firstPlayerScoreCount < secondPlayerScoreCount) {
			txtWinLoose.text = "You   win!";
			winLooseColor = new Color (0, 1, 0);
		} else if (firstPlayerScoreCount > secondPlayerScoreCount) {
			txtWinLoose.text = "You   loose!";
		} else {
			txtWinLoose.text = "Standoff!";
			winLooseColor = new Color (0, 0, 1);
		}

		for (float i = 0f; i <= 1.0f; i += 0.1f) {
			Color color = new Color (winLooseColor.r, winLooseColor.g, winLooseColor.b, i);
			txtWinLoose.color = color;
			yield return new WaitForSeconds (0.05f);
		}
		txtWinLoose.color = new Color (winLooseColor.r, winLooseColor.g, winLooseColor.b, 1);

		yield return new WaitForSeconds (3);

		for (float i = 1f; i >= 0f; i -= 0.1f) {
			Color color = new Color (winLooseColor.r, winLooseColor.g, winLooseColor.b, i);
			txtWinLoose.color = color;
			yield return new WaitForSeconds (0.05f);
		}
		txtWinLoose.color = new Color (0, 0, 0, 0);

		yield return new WaitForSeconds (1);

		Instantiate (ballTemplate);
		TimerController timer = GameObject.FindObjectOfType<TimerController> ();
		timer.RestartTimer ();

		firstPlayerScoreCount = 0;
		firstPlayerScoreText.text = firstPlayerScoreCount.ToString ();
		secondPlayerScoreCount = 0;
		secondPlayerScoreText.text = secondPlayerScoreCount.ToString ();
	}
}
