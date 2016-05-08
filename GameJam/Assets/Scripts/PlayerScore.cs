using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class PlayerScore : MonoBehaviour {
	[HideInInspector]
	public bool playerGainedPoint = false;

	public string[] comboTags;

	public string [] tenPointsItems = new string[38];
	public string [] fivePointsItems,  minusFivePointsItems, minusTenPointsItems;
	public int playerScore = 0;

	[HideInInspector]
	public string currentComboTag = ""; 
	[HideInInspector]
	public int[] comboCount = new int[20]; 

	int multiplier = 10; 

	public Text popUpText; // prefab
	public Text newText; //text instantiated 

	public GameObject canvas; 

	public string [] encouragementPhrases; 


	[HideInInspector]
	public Vector3 attachPosition; 
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (playerGainedPoint == true) {
			CreateRandomPhrase ();
			CheckingForCombos ();
			playerGainedPoint = false;
			Debug.Log ("Player Score: " + playerScore);
		}
	}

	void CreateRandomPhrase()
	{
		int randomNum = Random.Range (0, encouragementPhrases.Length);

		popUpText.text = encouragementPhrases [randomNum];


		newText = Instantiate (popUpText, new Vector3 (Random.Range (-10,10),Random.Range (-10,10),Random.Range (-10,10)), Quaternion.identity) as Text;
		newText.transform.SetParent(canvas.transform);
		//newText.transform.position = attachPosition;
		float locY = Random.Range (200, 450);
		float locX = Random.Range (200, 500);
		newText.transform.position = new Vector3 (locX, locY, 0.0F);
		//newText.transform.localPosition = new Vector3(0.0F, 205.0F, 0.0F); 

		//Debug.Log ("Instantiate (popUpText); " + popUpText.text);

	}


	void CheckingForCombos()
	{
		bool foundACombo = false; 
		int comboIndex = 0;
		for (int i = 0; i < comboTags.Length; i++){
			if (currentComboTag == comboTags [i]) {
				comboCount [i] += 1; 
				comboIndex = i;
				break;
			}
		}

		if (currentComboTag == "tuxedo" || currentComboTag == "snowsuit" || currentComboTag == "scubagear" || currentComboTag == "doctor"
			|| currentComboTag == "firefighter" || currentComboTag == "sailorguardian" || currentComboTag == "batman" || currentComboTag == "hipster")
		{
			if (comboCount [comboIndex] == 6) {
				playerScore += multiplier * 6; 
				foundACombo = true;
			}
		}
		else if (currentComboTag == "cowboy" || currentComboTag == "link" || currentComboTag == "mom" || currentComboTag == "sherlock" || currentComboTag == "bed")
		{
			if (comboCount [comboIndex] == 5) {
				playerScore += multiplier * 5;
				foundACombo = true;
			}
		}
		else 
		{
			if (comboCount [comboIndex] == 4) {
				playerScore += multiplier * 4;
				foundACombo = true;
			}
		}

		if (foundACombo == true) {
			comboCount [comboIndex] = 0;
			foundACombo = false; 
		}
	}
}
