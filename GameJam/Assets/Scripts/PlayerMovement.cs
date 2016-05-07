using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Physics.gravity = new Vector3(0.0F, -10.0F, 0);
		if (Input.GetKey (KeyCode.A))
		{
			//rb.velocity = new Vector3 (100.0F, 0.0F, 0);
			//rb.AddForce(new Vector3(-10.0F, 0.0F, 0));
			Physics.gravity = new Vector3(-70.0F, -10.0F, 0);
		}
		if (Input.GetKey (KeyCode.D)) {
			Physics.gravity = new Vector3 (70.0F, -10.0F, 0);
		}
		if (Input.GetKey (KeyCode.W)) {
			Physics.gravity = new Vector3 (0.0F, -10.0F, 70.0F);
		}
		if (Input.GetKey (KeyCode.S)) {
			Physics.gravity = new Vector3 (0.0F, -10.0F, -70.0F);
		}

	}
}
