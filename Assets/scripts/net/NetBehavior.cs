using UnityEngine;
using System.Collections;

public class NetBehavior : MonoBehaviour {

	void Start () {
		renderer.enabled = false;
	}

	public void Gather() {
		print ("Gathered!");
		Destroy (gameObject);
	}

	void Update () {
		Vector3 v3 = GameManager.PLAYER_1.transform.position - GameManager.PLAYER_2.transform.position;
		// net is located at the average position of the two player objects
		transform.position = (GameManager.PLAYER_1.transform.position + GameManager.PLAYER_2.transform.position) / 2;
		transform.localScale = new Vector3 (transform.localScale.x, v3.magnitude, transform.localScale.z);
		transform.rotation = Quaternion.FromToRotation (Vector3.up, v3);
		if (!renderer.enabled) {
			renderer.enabled = true;
		}
	}
}
