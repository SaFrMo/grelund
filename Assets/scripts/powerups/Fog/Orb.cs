using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour {

	// Attach to a sphere that will escort player through fog

	public GameObject Leash { get; set; }

	void Update () {
		if (Leash != null) {
			transform.position = Leash.transform.position + Vector3.back * 6;
		}
	}
}
