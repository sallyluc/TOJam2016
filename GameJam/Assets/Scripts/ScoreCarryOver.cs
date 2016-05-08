using UnityEngine;
using System.Collections;

public class ScoreCarryOver : MonoBehaviour {
	public int scoreCarryOver; 

	public GameObject ragdoll; 
	PlayerScore playerScore; 

	// Use this for initialization
	void Start () {
		playerScore = ragdoll.GetComponent<PlayerScore> ();
		DontDestroyOnLoad (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		scoreCarryOver = playerScore.playerScore; 
	}
}
