using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubtSpawner : MonoBehaviour {

	public List<GameObject> toSpawn;

	public float rate;

	Timer t;

	bool goingRight = false;

	void Start () {
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
		t = new Timer (rate, true);
	}

	void Update () {
		if (Camera.main.WorldToScreenPoint (transform.position).x >= Screen.width || Camera.main.WorldToScreenPoint (transform.position).x <= 0) {
			goingRight = !goingRight;
		}

		if (t.RunTimer()) {
			GameObject go = Instantiate (toSpawn[UnityEngine.Random.Range(0, toSpawn.Count - 1)]) as GameObject;
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
