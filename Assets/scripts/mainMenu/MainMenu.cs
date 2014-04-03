using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string gameName = "ShipStorm";
	public string clickText = "Click to start!";

	public GUISkin skin;

	float startingSize;

	void Start () {
		startingSize = skin.button.fontSize;
	}

	void OnGUI () {
		GUI.skin = skin;
		GUI.Box (new Rect (0, 0, Screen.width, Screen.height / 2), gameName);
		if (GUI.Button (new Rect (Screen.width / 4, Screen.height / 2, Screen.width / 2, Screen.height / 3), clickText)) {
			Application.LoadLevel ("demo");
		}
	}
}
