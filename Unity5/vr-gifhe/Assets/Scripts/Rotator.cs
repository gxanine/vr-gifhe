using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	 
	public float xx;
	public float yy;
	public float zz;

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3 (xx, yy, zz) * Time.deltaTime);
	}
}
