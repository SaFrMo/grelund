using UnityEngine;
using System.Collections;

public class CreateItem : MonoBehaviour {

	public GameObject pawnPrefab;

	bool placeholder = false;
	GameObject loadedObject = null;

	float zLevel = 10f;

	public void TempObject () {
		if (loadedObject != null) {

			if (!placeholder) {
				loadedObject = Instantiate (loadedObject) as GameObject;
				placeholder = true;
			}



			Vector3 pos = Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x,
											                          Input.mousePosition.y,
											                          zLevel));

			loadedObject.transform.position = pos;

			if (Input.GetMouseButtonDown(0)) {
				GameObject obj = Instantiate (loadedObject) as GameObject;
				obj.transform.position = pos;
				obj.transform.parent = transform;
			}
		}
	}

	public void Create (string item) {
		Destroy (loadedObject);
		placeholder = false;

		switch (item) {
		case "Pawn":
			loadedObject = pawnPrefab;
			break;
		};
	}

	void Update () {
		TempObject();
	}
}
