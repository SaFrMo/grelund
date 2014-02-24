using UnityEngine;
using System.Collections;

public class DoubtSpawner : MonoBehaviour {

	public GameObject doubtPrefab;

	Timer t = new Timer (0.5f, true);

	bool goingRight = false;

	void Start () {
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
	}

	void Update () {
		if (Camera.main.WorldToScreenPoint (transform.position).x >= Screen.width || Camera.main.WorldToScreenPoint (transform.position).x <= 0) {
			goingRight = !goingRight;
		}

		if (t.RunTimer()) {
			GameObject go = Instantiate (doubtPrefab) as GameObject;
			go.transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		}

		if (goingRight) {
			transform.Translate (Vector3.right);
		}
		else if (!goingRight) {
			transform.Translate (Vector3.left);
		}
	}
}
