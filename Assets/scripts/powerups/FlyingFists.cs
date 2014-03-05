using UnityEngine;
using System.Collections;

public class FlyingFists : Powerup {

	public GameObject flyingFistPrefab;

	//new float LifeSpan = 5f;

	void Start () {
		LifeSpan = 5f;
		Rate = .05f;
	}

	protected override void Action() {
		print ("ACTION!");
	}

}
