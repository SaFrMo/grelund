using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubtSpawner : MonoBehaviour {

	public List<GameObject> toSpawn;

	public float rate;

	Timer t;

	void Start () {
		//transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
		t = new Timer (rate, true);
	}

	void Update () {
		if (t.RunTimer()) {
			GameObject go = Instantiate (toSpawn[UnityEngine.Random.Range(0, toSpawn.Count)]) as GameObject;
			Vector3 randomLoc = Camera.main.ScreenToWorldPoint(new Vector3 (UnityEngine.Random.Range (0, Screen.width),
			                                                                Screen.height, 0));
			randomLoc.z = 0;
			go.transform.position = randomLoc;//= new Vector3 (transform.position.x, transform.position.y, 0);
		}
	}
}
