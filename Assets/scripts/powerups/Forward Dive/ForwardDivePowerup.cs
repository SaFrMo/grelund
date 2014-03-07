using UnityEngine;
using System.Collections;

public class ForwardDivePowerup : Powerup {

	public float rate;

	protected override void Action() {
		activator.transform.Translate (Vector3.up * rate);
		if (Mathf.Abs (activator.transform.position.z) <= 1f) {
			activator.transform.position = activator.transform.position + Vector3.back;
		}
	}

	protected override void Complete () {
		activator.transform.position = new Vector3 (activator.transform.position.x,
		                                            activator.transform.position.y,
		                                            0);
		Destroy (gameObject);
	}



	void Start () {
		LifeSpan = 1f;
		Rate = 0.05f;
	}
	

}
