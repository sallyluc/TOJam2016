using UnityEngine;
using System.Collections;

public class AttachClothing : MonoBehaviour {

	GameObject player; 
	PlayerScore playerScore; 
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Ragdoll");
		playerScore = player.GetComponent<PlayerScore> ();
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag != "Wall" && col.gameObject.tag !="attached") {
			for (int i = 0; i < playerScore.fivePointsItems.Length; i++){
				if (col.gameObject.tag == playerScore.fivePointsItems [i]) {
					playerScore.playerScore += 5; 
					playerScore.playerGainedPoint = true; 
					break;
				}
			}
			for (int i = 0; i < playerScore.tenPointsItems.Length; i++){
				if (col.gameObject.tag == playerScore.tenPointsItems [i]) {
					playerScore.playerScore += 10; 
					playerScore.playerGainedPoint = true; 
					break;
				}
			}
			for (int i = 0; i < playerScore.minusFivePointsItems.Length; i++){
				if (col.gameObject.tag == playerScore.minusFivePointsItems [i]) {
					playerScore.playerScore += -5; 
					break;
				}
			}
			for (int i = 0; i < playerScore.minusTenPointsItems.Length; i++){
				if (col.gameObject.tag == playerScore.minusTenPointsItems [i]) {
					playerScore.playerScore += -10; 
					break;
				}
			}
			playerScore.currentComboTag = col.gameObject.tag;
			col.gameObject.transform.parent = gameObject.transform;
			col.gameObject.tag = "attached";
		}

	}
}
