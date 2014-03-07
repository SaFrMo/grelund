using UnityEngine;
using System.Collections;

public class FogPowerup : Powerup {

	public GameObject fogPrefab;
	public GameObject orb;

	GameObject fog = null;
	static GameObject player1Orb = null;
	static GameObject player2Orb = null;

	void Start () {
		LifeSpan = 5f;
		Rate = 0.05f;
	}

	protected override void Action() {
		if (fog == null) {
			fog = Instantiate (fogPrefab) as GameObject;

			player1Orb = Instantiate (orb) as GameObject;
			player1Orb.GetComponent<Orb>().Leash = GameManager.PLAYER_1;

			player2Orb = Instantiate (orb) as GameObject;
			player2Orb.GetComponent<Orb>().Leash = GameManager.PLAYER_2;
		}
	}

	protected override void Complete () {
		Destroy (fog);
		base.Complete ();
	}
}
