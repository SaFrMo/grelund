using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			gameObject.GetComponent<CreateItem>().Create ("Pawn");
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}

	}


}
