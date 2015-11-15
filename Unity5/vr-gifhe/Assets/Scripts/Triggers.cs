using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Triggers : MonoBehaviour {

	public GameObject target;
	public GameObject player;

	private string itemName;

	// Use this for initialization
	void Start () {
		itemName = "";
		target.GetComponent<Rigidbody>().isKinematic = true;
		player.GetComponent<DragableDoor>().enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	// Run when entered on trigger
	void OnTriggerEnter (Collider player) { //I could player in here instead of item
				itemName = "first key";
				Debug.Log("Picked up the first ke1y!");

				target.GetComponent<Rigidbody>().isKinematic = false;
				player.GetComponent<DragableDoor>().enabled = true;
				gameObject.SetActive(false);
				Debug.Log("Picked up the first key!");
	}

}
