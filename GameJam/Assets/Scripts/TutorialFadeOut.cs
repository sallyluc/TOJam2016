using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class TutorialFadeOut : MonoBehaviour {
	Color oldMat, newMat; 
	bool toSecondImage = false;
	bool secondImageYield =false; 
	public GameObject other; 

	// Use this for initialization
	void Start () {
		oldMat = gameObject.GetComponent<Renderer>().material.color;
		newMat = new Color (oldMat.r, oldMat.g, oldMat.b, 1.0F);
		gameObject.GetComponent<Renderer>().material.color = newMat;

		oldMat = other.gameObject.GetComponent<Renderer> ().material.color;
		newMat = new Color (oldMat.r, oldMat.g, oldMat.b, 0.0F);
		other.GetComponent<Renderer>().material.color = newMat;
	}

	// Update is called once per frame
	void Update () {
		if (toSecondImage == false && secondImageYield == false)
			StartCoroutine (WaitToFade1 (3.0F));
		if (toSecondImage == true && secondImageYield == false)
			FadeIn ();
		if (toSecondImage == true && secondImageYield == true)
			StartCoroutine (WaitToFade2 (3.0F));
	}

	IEnumerator WaitToFade1(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		FadeOutAndDestroy1 ();
	}

	IEnumerator WaitToFade2(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		FadeOutAndDestroy2 ();
	}


	void FadeOutAndDestroy1 ()
	{
		if (toSecondImage == false) {
			oldMat = gameObject.GetComponent<Renderer> ().material.color;
			newMat = new Color (oldMat.r, oldMat.g, oldMat.b, oldMat.a - Time.deltaTime);

			gameObject.GetComponent<Renderer> ().material.color = newMat;
		}
		if (newMat.a <= 0) {
			toSecondImage = true;
		}
	}


	void FadeIn ()
	{
		oldMat = other.GetComponent<Renderer>().material.color;
		newMat = new Color (oldMat.r, oldMat.g, oldMat.b, oldMat.a + Time.deltaTime);
		oldMat = newMat; 

		other.GetComponent<Renderer>().material.color = newMat;

		if (newMat.a >= 1) {
			secondImageYield = true;
		}
	}

	void FadeOutAndDestroy2 ()
	{
		oldMat = other.GetComponent<Renderer>().material.color;
		newMat = new Color (oldMat.r, oldMat.g, oldMat.b, oldMat.a - Time.deltaTime);

		other.GetComponent<Renderer>().material.color = newMat;

		if (newMat.a <= 0) {
			Destroy (gameObject);
		}
	}


}
