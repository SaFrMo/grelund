using UnityEngine;
using System.Collections;

public class ENEMY_BASE : MonoBehaviour {

	public float movementRate = 0.05f;
	protected float rateOriginal;

	public void SpeedChange (float amount) {
		movementRate *= amount;
	}

	public void NormalSpeed () {
		movementRate = rateOriginal;
	}

	protected virtual void Start () {
		rateOriginal = movementRate;
		GameManager.Enemies.Add (gameObject);
	}

	public virtual void Complete () {
		GameManager.Enemies.Remove (gameObject);
		Destroy (gameObject);
	}
}
