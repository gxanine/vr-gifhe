using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Camera mainCamera ; // Add Camera to the script
	public float walkSpeed = 5.0f; // Set walk speed to 5.0f
	public float crchSpeed = 5.0f; // Set crouch speed to 5.0f
	public float runSpeed = 5.0f; // Set run speed to 5.0f
	public float mouseSpeed = 5.0f; // Set mouse sensitivity to 5.0f
	public float viewRange = 60.0f; // Set range of view to 60 degrees
	public float jumpingSpeed = 2.0f; // How height a jump is going to be (Used for Jumping)

	private CharacterController cc; // Add CharacterController to the script
	private float rotUD = 0; // Set mouse vertical rotation to 0
	private Transform tr; // Add Transform to the script (Used for Crouching)
	private float height; // (Used for Crouching)
	private float verticalVelocity = -3; // Gravity force (Used for a Gravity)



	// Use this for initialization
	void Start () {

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		cc = GetComponent<CharacterController> (); // Take CharacterController and call it cc
		//Screen.lockCursor = true; // Lock cursor
		height = cc.height; // Take height of CharacterController
		tr = transform; // Make transform shorter


	}

	// Update is called once per frame
	void Update () {

		// Quit when escaoe clicked
			if (Input.GetButton("Cancel")){
						Application.Quit();
			}

		// Restart when R pressed
			if (Input.GetKey(KeyCode.R)){
				Application.LoadLevel (Application.loadedLevelName);
			}

		// Rotation

			// Horizontal
			float rotLR = Input.GetAxis ("Mouse X") * mouseSpeed;
			transform.Rotate (0, rotLR, 0); // (x, y, z)

			//Vertical
			rotUD -= Input.GetAxis ("Mouse Y") * mouseSpeed;
			rotUD = Mathf.Clamp (rotUD, -viewRange, viewRange); // Set range for vertical rotation values (source, min, max)

			mainCamera.transform.localRotation = Quaternion.Euler (rotUD, 0, 0);

		// Movement

			// Walking
			float speed = walkSpeed; // Default movement speed

			// Running
			if (Input.GetKey("left shift") || Input.GetKey("right shift")){ // Change speed if left or right shift is pressed and hold
				speed = runSpeed;
			}

			// Crouching
			float h = height;

			if (Input.GetKey("c")) {
				speed = crchSpeed;
				h = 0.5f * height;
			}

			Vector3 tmpPosition = tr.position;
			float lastHeight = cc.height; // Crouch/stand up smoothly
			cc.height = Mathf.Lerp(cc.height, h, 5*Time.deltaTime);
			tmpPosition.y += (cc.height-lastHeight)/2; // Fix vertical position


		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		moveHorizontal = (moveHorizontal * speed) / 1.5f; // Make horizontal move slower than vertical by factor 1.5f
		moveVertical = (moveVertical * speed);

			// Gravity
			verticalVelocity += Physics.gravity.y * Time.deltaTime; // Gravity is equals to gravity force * every second | Longer falling = Faster falling
			if (cc.isGrounded) { // If CharacterController is on the ground make the gravity equal to -3
				verticalVelocity = -3; // Used -3 because it looks more natural
			}


			// Jumping
			if (cc.isGrounded && Input.GetButton("Jump")) { // If CharacterController is on the ground and 'Jump' button is pressed change the velocity to value of jumpingSpeed
				verticalVelocity = jumpingSpeed;
			}

			// Main part of Movement
			Vector3 movement = new Vector3 (moveHorizontal, verticalVelocity, moveVertical);

			movement = transform.rotation * movement;

			cc.Move (movement * Time.deltaTime);



	}

}
