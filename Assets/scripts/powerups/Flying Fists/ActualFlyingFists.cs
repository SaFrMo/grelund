﻿using UnityEngine;
using System.Collections;

public class ActualFlyingFists : MonoBehaviour {

	public float rate = 0.5f;

	Timer life = new Timer (1f);

	ParticleSystem ps;

	void Start () {
		ps = GetComponentInChildren<ParticleSystem>();

	}

	void OnCollisionEnter (Collision c) {
		if (!c.gameObject.CompareTag ("Player")) {
			try {
			c.gameObject.GetComponent<Doubt>().Complete();
			}
			catch {
				Debug.Log ("Hit object didn't have <Doubt> component");
			}
			//particleSystem.Stop ();
		}
	}

	void Update () {
		print (transform.position);
		/*
		if (!ps.isPlaying) {

			ps.Play ();
		}
*/
		rigidbody.MovePosition (transform.position + 
		                        Vector3.up * rate //+ //* MovementModifier() +
		                        //Vector3.left * MovementModifier() +
		                        //Vector3.right * MovementModifier());
		                        );
		
		// destroy when offscreen
		if (Camera.main.WorldToViewportPoint(transform.position).y < 0f ||
		    Camera.main.WorldToViewportPoint(transform.position).x > 1f ||
		    Camera.main.WorldToViewportPoint(transform.position).x < 0f) {
			print ("off");
			Destroy (gameObject);
		}

		// destroy after 1 second
		if (life.RunTimer()) {
			Destroy(gameObject);
		} 
	}
}
