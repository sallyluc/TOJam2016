using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float timer = 60F;//in seconds
	float timerInMinutes = 0F; 
	float timerInRemainingSeconds = 0;

	string timerAsString;

	public Font timerFont;
	// Use this for initialization
	public Text timerText; 
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (timer >= 0) {
			timer -= Time.deltaTime;

			timerInMinutes = (int)timer/60;
			timerInRemainingSeconds = (int)timer%60; 



			if(timerInRemainingSeconds <=9 && timerInRemainingSeconds>=0)
				timerAsString = timerInMinutes + ":" + "0" + timerInRemainingSeconds;
			else
				timerAsString = timerInMinutes + ":" + timerInRemainingSeconds;

		} 
		else {
			// End game
		}
		timerText.text = timerAsString;
	}
}
