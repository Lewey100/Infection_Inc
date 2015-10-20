using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 3.0f;
	public float mouseSensitivity = 3.0f;

	float verticalRotation = 0;
	public float upDownRange = 60.0f;

	public Camera playerCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//Camera Movement
		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		playerCamera.transform.rotation = Quaternion.Euler(verticalRotation,0,0);


		//Player Movement
		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		Vector3 speed = new Vector3 (sideSpeed, 0, forwardSpeed);

		speed = transform.rotation * speed;

		CharacterController cc = GetComponent<CharacterController> ();

		cc.SimpleMove (speed);

		if (Input.GetKey(KeyCode.Escape))
			Screen.lockCursor = false;
		else
			Screen.lockCursor = true;
	}
}
