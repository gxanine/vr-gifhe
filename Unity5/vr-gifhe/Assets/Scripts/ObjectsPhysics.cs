using UnityEngine;
using System.Collections;

public class ObjectsPhysics : MonoBehaviour {

	public float pushPower = 2.0f;

	void OnControllerColliderHit (ControllerColliderHit hit) {

		Rigidbody body =  hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;

		if (hit.moveDirection.y < -0.3f)
			return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;

	}

}
