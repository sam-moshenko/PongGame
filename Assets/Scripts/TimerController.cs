using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimerController : MonoBehaviour {
	public int seconds = 60;
	Text text;


	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		Color color = new Color (1, 1, 1, 0);
		text.color = color;
		TimeSpan time = TimeSpan.FromSeconds(seconds);
		text.text = string.Format ("{0:D2}:{1:D2}", time.Minutes, time.Seconds); 
	}
	
	public void RestartTimer () {
		//StopCoroutine does not work
		StartCoroutine (TimerFire ());
	}

	IEnumerator TimerFire () {
		for (int i = seconds; i >= 0; i--) {
			TimeSpan time = TimeSpan.FromSeconds(i);
			string timeStr = string.Format ("{0:D2}:{1:D2}", time.Minutes, time.Seconds); 
			text.text = timeStr;
			yield return new WaitForSeconds (1);
		}

		GameController game = GameObject.FindObjectOfType<GameController> ();
		StartCoroutine (game.GameOver ());
	}
}
