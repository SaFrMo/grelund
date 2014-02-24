using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Doubt : MonoBehaviour {

	Color DOUBT_COLOR = Color.red;

	public float Rate { get; set; }
	public float Constant { get; set; }

	void Start () {
		renderer.material.color = DOUBT_COLOR;
		Rate = 100f;
	}

	float MovementModifier () {
		return UnityEngine.Random.Range(0, Rate) * 0.0002f;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.MovePosition (transform.position + 
		                        Vector3.down * MovementModifier() +
		                        Vector3.left * MovementModifier() +
		                        Vector3.right * MovementModifier());
	}
}
