using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string gameName = "You seem to have died...";
	public string clickText = "Click to try again";

	public GUISkin skin;

	float startingSize;

	void Start () {
		startingSize = skin.button.fontSize;
	}

	void OnGUI () {
		GUI.skin = skin;
		GUI.Box (new Rect (0, 0, Screen.width, Screen.height / 2), gameName);
		if (GUI.Button (new Rect (Screen.width / 4, Screen.height / 2, Screen.width / 2, Screen.height / 3), clickText)) {
			Application.LoadLevel ("instructions");
		}
	}
}
