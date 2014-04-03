﻿using UnityEngine;
using System.Collections;

public class FogPowerup : Powerup {

	public float maximumHeatSeekingSpeed = 5f;

	public GameObject fogPrefab;
	public GameObject orb;

	GameObject fog = null;
	static GameObject player1Orb = null;
	static GameObject player2Orb = null;

	GameObject closestPlayer = null;

	void Start () {
		LifeSpan = 5f;
		Rate = 0.05f;
	}

	protected override void Action() {
		if (fog == null) {
			fog = Instantiate (fogPrefab) as GameObject;
			fog.transform.position = new Vector3 (0, 0, -5);

			player1Orb = Instantiate (orb) as GameObject;
			player1Orb.GetComponent<Orb>().Leash = GameManager.PLAYER_1;

			player2Orb = Instantiate (orb) as GameObject;
			player2Orb.GetComponent<Orb>().Leash = GameManager.PLAYER_2;
		}
	}

	protected override void Update () {
		base.Update ();
		// which is the closer player?
		if (Vector3.Distance (GameManager.PLAYER_1.transform.position, transform.position) <= Vector3.Distance (GameManager.PLAYER_2.transform.position, transform.position)) {
			closestPlayer = GameManager.PLAYER_1;
		}
		else {
			closestPlayer = GameManager.PLAYER_2;
		}
		// move toward the closer player
		rigidbody.MovePosition (Vector3.MoveTowards (transform.position, closestPlayer.transform.position, maximumHeatSeekingSpeed * Time.deltaTime));
	}

	protected override void Complete () {
		Destroy (fog);
		base.Complete ();
	}
}
