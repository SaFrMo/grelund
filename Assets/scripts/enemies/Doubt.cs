using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Doubt : ENEMY_BASE {

	Color DOUBT_COLOR = Color.red;

	public float Rate { get; set; }
	public float Constant { get; set; }

	public float scaleRate = 0.001f;

	void Start () {
		renderer.material.color = DOUBT_COLOR;
		Rate = 100f;
	}

	float MovementModifier () {
		return UnityEngine.Random.Range(0, Rate) * 0.0002f;
	}

	void OnCollisionStay (Collision c) {
		transform.localScale = new Vector3 (transform.localScale.x - scaleRate,
		                                     transform.localScale.y - scaleRate,
		                                     transform.localScale.z - scaleRate);
	}

	void StopExisting() {
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
		rigidbody.MovePosition (transform.position + 
		                        Vector3.down * MovementModifier() +
		                        Vector3.left * MovementModifier() +
		                        Vector3.right * MovementModifier());
		if (transform.localScale.magnitude <= 0.25f) {
			StopExisting();
		}
	}
}
