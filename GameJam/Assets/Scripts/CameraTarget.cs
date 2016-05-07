using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {

	int rotationValue = 90; 
	int currentRotation = 0; 
	int index = 0; 
	float moveIndex = 0.0F; 
	bool rotationLeftNeeded = false;
	bool rotationRightNeeded = false;


	float currentXLoc;
	float currentYLoc;
	float currentZLoc;

	float ragdollLocX, ragdollLocY, ragdollLocZ;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//CameraRotation ();
		CameraMovement ();


	}
		
	void CameraMovement ()
	{
		ragdollLocX = GameObject.Find ("Ragdoll").transform.position.x;
		currentYLoc = gameObject.transform.position.y;
		ragdollLocZ = GameObject.Find ("Ragdoll").transform.position.z;
		transform.position = new Vector3 (ragdollLocX, currentYLoc, ragdollLocZ);
	}
	/*void CameraMovement ()
	{
		ragdollLocX = GameObject.Find ("Ragdoll").transform.position.x; 
		ragdollLocY = GameObject.Find ("Ragdoll").transform.position.y; 
		ragdollLocZ = GameObject.Find ("Ragdoll").transform.position.z; 

		currentYLoc = gameObject.transform.position.y;

		if (currentXLoc <= 45 || ragdollLocX <= 45) {
			ragdollLocX = 45;
		} else if (currentXLoc >= 490 || ragdollLocX >= 490) {
			ragdollLocX = 490;
		}
		currentXLoc = ragdollLocX;
		currentZLoc = ragdollLocZ;

		
		gameObject.transform.position = new Vector3 (currentXLoc, currentYLoc, currentZLoc);
			
	}
*/
	void CameraRotation ()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			rotationLeftNeeded = true; 
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			rotationRightNeeded = true; 
		}


		if (rotationLeftNeeded == true) {
			index -= 1;
		} else {
			if (rotationRightNeeded == true)
				index += 1;
		}


		if (index >= rotationValue || index <= -rotationValue) {
			currentRotation += index; 
			index = 0; 
			rotationLeftNeeded = false; 
			rotationRightNeeded = false; 
		}
		gameObject.transform.localEulerAngles = new Vector3(0,currentRotation + index,0);
	}
}
