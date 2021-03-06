﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Powerup : MonoBehaviour {

	// BASE CLASS FOR ALL POWERUPS
	// =============================
	// All powerups:
	//		X Activate on player touch
	//		X Have a lifespan, then are destroyed
	//		X Are destroyed when they go offscreen

	protected Timer lifeTimer = null;
	protected GameObject activator = null;

	// Everything here needs to be overridden in the derived class
	public virtual float LifeSpan { get; protected set; }
	public virtual float Rate { get; protected set; }

	protected virtual void Action () {
		// destroy attached models
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}
	}

	// this can be overridden to give increased on-destruction functionality
	protected virtual void Complete () {
		Destroy (gameObject);
	}



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
				// stops the powerup so it doesn't destroy itself when going offscreen after activation
				Rate = 0;
				// tags the colliding player as the activator
				activator = c.gameObject;
			}
			// keeps player from drifting
			c.rigidbody.velocity = Vector3.zero;
		}
		else {
			Physics.IgnoreCollision(c.collider, collider);
		}
	}

	protected virtual void DownwardMotion () {
		rigidbody.MovePosition (transform.position + Vector3.down * Rate );
	}

	protected virtual void Update () {
		if (lifeTimer != null) {
			// runs Action() while the powerup is still "alive"
			Action ();
			// kills the powerup's effect after a set time
			if (lifeTimer.RunTimer()) {
				Complete ();
				//Destroy (gameObject);
			}
		}

		DownwardMotion();
		//+ //* MovementModifier() +
		                        //Vector3.left * MovementModifier() +
		                        //Vector3.right * MovementModifier());
		                        
		
		// destroy when offscreen (the .5s allow for some give so that they don't disappear while still
		// partially onscreen)
		if (Camera.main.WorldToViewportPoint(transform.position).y < -.5f ||
		    Camera.main.WorldToViewportPoint(transform.position).x > 1.5f ||
		    Camera.main.WorldToViewportPoint(transform.position).x < -0.5f) {
			Destroy (gameObject);
		}
	}
}
