using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
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
	}
}
