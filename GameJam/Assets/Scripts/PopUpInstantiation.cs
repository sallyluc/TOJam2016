using UnityEngine;
using System.Collections;

public class PopUpInstantiation : MonoBehaviour {
	Material gameTexture;
	float newAlpha = 1; 

	// Use this for initialization
	void Start () {
		//gameTexture = gameObject.GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (WaitToFade (3.0F));
		FadeOutAndDestroy ();
	}

	IEnumerator WaitToFade(float waitTime) {
		yield return new WaitForSeconds(waitTime);
	}

	void FadeOutAndDestroy()
	{
	/*	newAlpha -= Time.deltaTime; 
		gameTexture.color.a = newAlpha; 

		if (gameTexture.color.a <= 0)
			Destroy (gameObject);
*/	}

}
