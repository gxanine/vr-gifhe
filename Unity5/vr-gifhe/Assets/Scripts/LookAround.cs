using UnityEngine;
using System.Collections;

public class LookAround : MonoBehaviour {

	public Camera mainCamera ; // Add Camera to the script
	public float mouseSpeed = 5.0f; // Set mouse sensitivity to 5.0f
	public float viewRange = 60.0f; // Set range of view to 60 degrees
	public GameObject player;

	private float rotUD = 0; // Set mouse vertical rotation to 0

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// Rotation

			// Horizontal
			float rotLR = Input.GetAxis ("Mouse X") * mouseSpeed;
			transform.Rotate (0, rotLR, 0); // (x, y, z)

			//Vertical
			rotUD -= Input.GetAxis ("Mouse Y") * mouseSpeed;
			rotUD = Mathf.Clamp (rotUD, -viewRange, viewRange); // Set range for vertical rotation values (source, min, max)

			mainCamera.transform.localRotation = Quaternion.Euler (rotUD, 0, 0);

			float cameraRot = mainCamera.transform.eulerAngles.y;
			Vector3 rotation = new Vector3 (0.0f, cameraRot, 0.0f);
			player.transform.Rotate(rotation);/////////////////////////////

	}
}
