using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	// BASE CLASS FOR ALL POWERUPS
	// =============================
	// All powerups:
	//		X Activate on player touch
	//		Have a lifespan, then are destroyed
	//		Are destroyed when the go offscreen

	protected Timer lifeTimer = null;
	public virtual float LifeSpan { get; protected set; }
	protected virtual void Action () {}


	protected void OnCollisionEnter (Collision c) {
		if (c.gameObject.CompareTag ("Player")) {

			//==================================
			// PUT THE ACTIVATION ANIMATION HERE
			//==================================

			if (lifeTimer == null) {
				// sets the timer and makes the powerup invisible
				GetComponent<MeshRenderer>().enabled = false;
				GetComponent<BoxCollider>().enabled = false;
				lifeTimer = new Timer (LifeSpan);
			}
			// keeps player from drifting
			c.rigidbody.velocity = Vector3.zero;
		}
	}

	protected void Update () {
		if (lifeTimer != null) {
			// runs Action() while the powerup is still "alive"
			Action ();
			// kills the powerup's effect after a set time
			if (lifeTimer.RunTimer()) {
				Destroy (gameObject);
			}
		}
	}
}
