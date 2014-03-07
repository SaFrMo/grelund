using UnityEngine;
using System.Collections;

public class ENEMY_BASE : MonoBehaviour {

	protected float rate = 0.05f;
	protected float rateOriginal;

	public void SpeedChange (float amount) {
		rate *= amount;
	}

	public void NormalSpeed () {
		rate = rateOriginal;
	}

	protected virtual void Start () {
		rateOriginal = rate;
		GameManager.Enemies.Add (gameObject);
	}

	public virtual void Complete () {
		GameManager.Enemies.Remove (gameObject);
		Destroy (gameObject);
	}
}
