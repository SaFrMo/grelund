using UnityEngine;
using System.Collections;

public class SlowerSpeederPowerup : Powerup {

	// SLOWER-SPEEDER POWERUP
	// ========================
	// This is really four powerups in one. There are two modules, Slow Down and Speed Up,
	// for either of two targets - the activating player or enemies. The individual
	// type of the powerup will set itself up at Start ().

	public float deltaSpeed = 0.5f;

	public bool ToSlow { get; protected set; }
	public bool ToPlayer { get; protected set; }	

	bool deltaApplied = false;

	void Start () {
		ToSlow = SaFrMo.GetRandomBool();
		ToPlayer = SaFrMo.GetRandomBool();
		LifeSpan = 5f;
		Rate = 0.05f;
	}

	protected override void Action() {
		if (!deltaApplied) {
			if (ToPlayer) {
				activator.GetComponent<WASDMovement>().SpeedChange (ToSlow ? deltaSpeed : 1 + deltaSpeed);
			}
			else {
				foreach (GameObject enemy in GameManager.Enemies) {
					enemy.GetComponent<ENEMY_BASE>().SpeedChange (ToSlow ? deltaSpeed : 1 + deltaSpeed);
				}
			}
			deltaApplied = true;
		}
	}

	protected override void Complete() {
		if (ToPlayer) {
			activator.GetComponent<WASDMovement>().NormalSpeed();
		}
		else {
			foreach (GameObject enemy in GameManager.Enemies) {
				enemy.GetComponent<ENEMY_BASE>().NormalSpeed ();
			}
		}
		base.Complete ();
	}
}
