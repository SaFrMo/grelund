using UnityEngine;
using System.Collections;

public class FlyingFists : Powerup {

	public float minFistPause = 0.3f;
	public float maxFistPause = 0.8f;
	public GameObject flyingFistPrefab;

	Timer fistCreation; 

	void Start () {
		fistCreation = new Timer (minFistPause, maxFistPause, true);
		LifeSpan = 5f;
		Rate = .05f;
	}

	protected override void Action() {
		if (fistCreation.RunTimer()) {
			GameObject fist = GameObject.Instantiate (flyingFistPrefab) as GameObject;
			fist.transform.position = activator.transform.position + Vector3.up;
		}
	}

}
