using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndSceneScore : MonoBehaviour {
	GameObject scoreCarryOverObj; 
	ScoreCarryOver scoreCarryOver; 

	public Text score; 
	// Use this for initialization
	void Start () {
		scoreCarryOverObj = GameObject.Find ("ScoreCarryOver"); 
		scoreCarryOver = scoreCarryOverObj.GetComponent<ScoreCarryOver> ();
		score.text = "" + scoreCarryOver.scoreCarryOver; 

	}
	
	// Update is called once per frame
	void Update () {
		score.text = "" + scoreCarryOver.scoreCarryOver; 
	}
}
