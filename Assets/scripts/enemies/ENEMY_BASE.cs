using UnityEngine;
using System.Collections;

public class ENEMY_BASE : MonoBehaviour {

	public float movementRate = 0.05f;
	protected float rateOriginal;

	public float lowRotation = -150f;
	public float highRotation = 150f;
	
	private float rotationX;
	private float rotationY;
	private float rotationZ;

	public void SpeedChange (float amount) {
		movementRate *= amount;
	}

	public void NormalSpeed () {
		movementRate = rateOriginal;
	}

	protected virtual void Start () {
		rateOriginal = movementRate;
		GameManager.Enemies.Add (gameObject);
		rotationX = UnityEngine.Random.Range (lowRotation, highRotation);
		rotationY = UnityEngine.Random.Range (lowRotation, highRotation);
		rotationZ = UnityEngine.Random.Range (lowRotation, highRotation);
	}

	public virtual void Complete () {
		GameManager.Enemies.Remove (gameObject);
		Destroy (gameObject);
	}

	protected virtual void Update () {
		transform.RotateAround (transform.position, Vector3.right, rotationX);
		transform.RotateAround (transform.position, Vector3.forward, rotationZ);
		transform.RotateAround (transform.position, Vector3.up, rotationY);
	}
}