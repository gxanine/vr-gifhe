using UnityEngine;
using System.Collections;

public class DragableDoor : MonoBehaviour {

	public float speed = 5.0f; // Set mouse sensitivity to 5.0f
	public GameObject player;

	private float rotLR = 0; // Set mouse vertical rotation to 0
	private Transform tr; // Add Transform to the script

	void Start() {



	}

	GameObject grabbedObject;
	float grabbedObjectSize;
	GameObject GetMouseHoverObject(float range)
	{
		Vector3 position = gameObject.transform.position;
		RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * range;

		if (Physics.Linecast(position, target, out raycastHit))
			return raycastHit.collider.gameObject;
		return null;

	}

	void TryGrabObject(GameObject grabObject)
	{
		if (grabObject == null || !CanGrab(grabObject))
			return;
		grabbedObject = grabObject;
		grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
	}
	bool CanGrab(GameObject canidate)
	{
		return canidate.GetComponent<Rigidbody> () != null;
	}
	void DropObject()
	{
		if (grabbedObject == null)
			return;


		if (grabbedObject.GetComponent<Rigidbody> () != null)
		{
			grabbedObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
		grabbedObject = null;
	}

	void Update () {

		if (Input.GetButtonDown("Fire1") || Input.GetButtonUp("Fire1") )
		{
			Debug.Log("Pressed");
			if (grabbedObject == null) {
				TryGrabObject(GetMouseHoverObject(5));
				Debug.Log("Grabbed");
			}
			else {
				DropObject();
				Debug.Log("Dropped");
			}
		}

		if (grabbedObject != null)
		{

			rotLR = Input.GetAxis ("Mouse X") * speed;
			grabbedObject.transform.Rotate (0, rotLR, 0);
			Debug.Log("Rotated");
		}


	}

}
