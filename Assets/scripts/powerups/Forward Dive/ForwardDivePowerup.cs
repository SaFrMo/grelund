using UnityEngine;
using System.Collections;

public class ForwardDivePowerup : Powerup {

	public float rate;

	protected override void Action() {
		/*
		if (!activator.GetComponent<BoxCollider>().isTrigger) {
			activator.GetComponent<BoxCollider>().isTrigger = true;
		}
		*/
		activator.transform.Translate (Vector3.up * rate);
	}

	protected override void Complete () {
		activator.GetComponent<BoxCollider>().isTrigger = false;
		base.Complete();
	}



	void Start () {
		LifeSpan = 1f;
		Rate = 0.05f;
	}
	

}
