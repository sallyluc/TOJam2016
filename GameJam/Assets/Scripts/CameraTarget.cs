using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {

	int rotationValue = 0; 
	int currentRotation = 0; 
	int index = 0; 
	float moveIndex = 0.0F; 
	bool rotationLeftNeeded = false;
	bool rotationRightNeeded = false;


	bool rotateToX = false, rotateToZ = true; 
	string currentFace = "front"; 

	float currentXLoc;
	float currentYLoc;
	float currentZLoc;

	float ragdollLocX, ragdollLocY, ragdollLocZ;

	public GameObject ragDoll;

	int dir = 0; // front, right, back, left;

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		CameraRotation ();
		CameraMovement ();

		Debug.Log (dir);
	}

	void CameraMovement ()
	{
		ragdollLocX = ragDoll.transform.position.x;
		currentYLoc = gameObject.transform.position.y;
		ragdollLocZ = ragDoll.transform.position.z;
		float clampDollX = Mathf.Clamp (ragdollLocX, 221, 410);//112, -270
		float clamDollZ = Mathf.Clamp(ragdollLocZ, 112, -220);
		transform.position = new Vector3 (clampDollX, currentYLoc, ragdollLocZ);
	}



	int CameraFaceDirection(bool increment) // false = subtract. true = add
	{
		if (increment == false) {
			dir -= 1;
		} else {
			dir += 1;
		}

		if (dir < 0)
			dir = 3;

		if (dir > 3)
			dir = 0; 

		return dir; 
	}

	void CameraRotation ()
	{
		if (index == 0) {
			if (rotateToX == true) {
				if (Input.GetKeyDown (KeyCode.A)) {
					if (dir == 1) {
						rotationRightNeeded = true;
						CameraFaceDirection (true);
					} else {
						rotationLeftNeeded = true; 
						CameraFaceDirection (false);
					}

					rotateToX = false; 
					rotateToZ = true; 
				}
				if (Input.GetKeyDown (KeyCode.D)) {
					if (dir == 3) {
						rotationRightNeeded = true;
						CameraFaceDirection (true);
					} else {
						rotationLeftNeeded = true;
						CameraFaceDirection (false);
					}
					rotateToX = false; 
					rotateToZ = true; 
				}
			}
			if (rotateToZ == true) {
				if (Input.GetKeyDown (KeyCode.W)) {
					if (dir == 0) {
						rotationRightNeeded = true;
						CameraFaceDirection (true);
					} else {
						rotationLeftNeeded = true;
						CameraFaceDirection (false);
					}
					rotateToX = true; 
					rotateToZ = false; 
				}
				if (Input.GetKeyDown (KeyCode.S)) {

					if (dir == 2) {
						rotationLeftNeeded = true; 
						CameraFaceDirection (false);
					} else {
						rotationRightNeeded = true;
						CameraFaceDirection (true);
					}
					rotateToX = true; 
					rotateToZ = false; 
				}
			}
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
