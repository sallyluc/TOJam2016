using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class PopUpInstantiation : MonoBehaviour {
	Color oldMat, newMat; 

	PlayerScore playerScore;

	// Use this for initialization
	void Start () {
		playerScore = GameObject.Find ("Ragdoll").GetComponent<PlayerScore> ();

		oldMat = playerScore.popUpText.color;
		newMat = new Color (oldMat.r, oldMat.g, oldMat.b, 1.0F);
		playerScore.newText.color = newMat;
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine (WaitToFade (3.0F));
	}

	IEnumerator WaitToFade(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		FadeOutAndDestroy ();
	}

	void FadeOutAndDestroy()
	{
		oldMat = playerScore.newText.color;
		newMat = new Color (oldMat.r, oldMat.g, oldMat.b, oldMat.a - Time.deltaTime);

		playerScore.newText.color = newMat; 
		if (newMat.a <= 0)
			Destroy (gameObject);
	}

}