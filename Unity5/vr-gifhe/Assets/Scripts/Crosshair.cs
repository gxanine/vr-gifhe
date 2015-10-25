using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	Rect crosshairRect;
	Texture crosshairTexture;

	public float size = 0.1f;
	public string path = "Textures/Crosshair";

	// Use this for initialization
	void Start () {
		float crosshairSize = Screen.width*size;
		crosshairTexture = Resources.Load(path) as Texture;
		crosshairRect = new Rect (Screen.width / 2 - crosshairSize / 2,
			Screen.height / 2 - crosshairSize / 2,
			crosshairSize, crosshairSize);

	}

	// Update is called once per frame
	void OnGUI () {
		GUI.DrawTexture(crosshairRect, crosshairTexture);
	}
}
