using UnityEngine;
using System.Collections;

public class TeamWork : MonoBehaviour {

	// TEAMWORK
	// ===========
	// Register player collision. Create a Net object in between the players. Net object moves with players.


	static GameObject NET = null;
	public GameObject netPrefab;



	// Register player collision
	/*
	void OnCollisionEnter (Collision c) {
		if (c.gameObject.CompareTag (playerTag)) {
			if (NET == null) {
				// Create Net object in between players
				NET = GameObject.Instantiate (netPrefab) as GameObject;
			}
			else {
				NET.GetComponent<NetBehavior>().Gather();
			}
		}
	}
	*/

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (NET == null) {
				// Create Net object in between players
				NET = GameObject.Instantiate (netPrefab) as GameObject;
			}
			else {
				NET.GetComponent<NetBehavior>().Gather();
			}
		}
	}

}
