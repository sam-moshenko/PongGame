using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
	public Text firstPlayerScoreText;
	public Text secondPlayerScoreText;
	public Text timerText;
	public GameObject ballPrefab;

	public void Start () {
		HideText ();
	}

	public void HideText() {
		Color color = new Color (0, 0, 0, 0);
		firstPlayerScoreText.color = color;
		secondPlayerScoreText.color = color;
		timerText.color = color;
	}

	public void AnimationEnds() {
		StartCoroutine (ShowText ());

		Instantiate (ballPrefab);
	}

	private IEnumerator ShowText() {
		for (float i = 0f; i < 1.0f; i += 0.1f) {
			Color color = new Color (1, 1, 1, i);
			firstPlayerScoreText.color = color;
			secondPlayerScoreText.color = color;
			timerText.color = color;
			yield return new WaitForSeconds (0.05f);
		}
		timerText.gameObject.GetComponent<TimerController> ().RestartTimer ();
	}
}
