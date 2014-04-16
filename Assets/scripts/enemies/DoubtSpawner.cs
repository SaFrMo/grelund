using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubtSpawner : MonoBehaviour {
	
	// IMPLEMENTATION: Attach to Doubt Spawner GO
	// TODO: Work out rate increase formula
	/*
	private float ApplyRateIncreaseFormula (float rateIn) {
		// here, bucko
	}
	*/
	public List<GameObject> toSpawn;
	
	public float rate;
	
	Timer t;
	// increases spawning rate every scoreIncreaseRate seconds
	Timer rateIncrease = new Timer (5f, true);

	private IEnumerator Spawn () {
		for (;;) {
			GameObject go = Instantiate (toSpawn[UnityEngine.Random.Range(0, toSpawn.Count - 1)]) as GameObject;
			// instantiates object at a random location
			Vector3 randomLoc = Camera.main.ScreenToWorldPoint(new Vector3 (UnityEngine.Random.Range (0, Screen.width),
			                                                                Screen.height, 0));
			randomLoc.z = 0;
			go.transform.position = randomLoc;
			yield return new WaitForSeconds (rate);
		}

	}
	
	void Start () {
		//t = new Timer (rate, true);
		GameObject go = Instantiate (toSpawn[UnityEngine.Random.Range(0, toSpawn.Count - 1)]) as GameObject;
		// instantiates object at a random location
		Vector3 randomLoc = Camera.main.ScreenToWorldPoint(new Vector3 (UnityEngine.Random.Range (0, Screen.width),
		                                                                Screen.height, 0));
		randomLoc.z = 0;
		go.transform.position = randomLoc;
		StartCoroutine (Spawn ());
	}

	public float minRate = 0.11f;
	
	void Update () {
		rate = Mathf.Clamp (rate, 0.11f, Mathf.Infinity);


		// increases rate of spawning every rateIncrease.Timer seconds

		if (rateIncrease.RunTimer() && rate >= minRate) {
			rate *= .8f;//ApplyRateIncreaseFormula (rate);
		}
		rate = Mathf.Clamp (rate, 0.11f, Mathf.Infinity);

		// spawns a new object when appropriate
		//if (t.RunTimer()) {
			// chooses object at random from list of spawnable objects
			
	}
}