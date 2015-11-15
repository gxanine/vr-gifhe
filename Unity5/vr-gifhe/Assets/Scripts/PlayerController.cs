using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Camera mainCamera ; // Add Camera to the script
	public float walkSpeed = 5.0f; // Set walk speed to 5.0f
	public float crchSpeed = 5.0f; // Set crouch speed to 5.0f
	public float runSpeed = 5.0f; // Set run speed to 5.0f
	public float superSpeed = 50.0f; // Set run speed to 5.0f
	public float jumpingSpeed = 2.0f; // How height a jump is going to be (Used for Jumping)

	private CharacterController cc; // Add CharacterController to the script
	private Transform tr; // Add Transform to the script (Used for Crouching)
	private float height; // (Used for Crouching)
	private float verticalVelocity = -3; // Gravity force (Used for a Gravity)



	// Use this for initialization
	void Start () {

		cc = GetComponent<CharacterController> (); // Take CharacterController and call it cc
		//Screen.lockCursor = true; // Lock cursor
		height = cc.height; // Take height of CharacterController
		tr = transform; // Make transform shorter


	}

	// Update is called once per frame
	void Update () {


		//Cheats

			//SuperSpeed!
				if (Input.GetKey("y")) {
					if (Input.GetKey("u")) {
						if (Input.GetKey("i")) {
							if (Input.GetKey("o")) {
								if (Input.GetKey("p")) {
									if (Input.GetKey("o")) {
										if (Input.GetKey("i")) {
											if (Input.GetKey("u")) {
												if (Input.GetKey("y")) {
													if (Input.GetKey("t")) {
														runSpeed = runSpeed * 1000;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}

		// Movement

			// Walking
			float speed = walkSpeed; // Default movement speed

			// Running
			if (Input.GetKey("left shift") || Input.GetKey("right shift")){ // Change speed if left or right shift is pressed and hold
				speed = runSpeed;
			}

			if (Input.GetKey("p")){ // Change speed if left or right shift is pressed and hold
				speed = superSpeed;
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
