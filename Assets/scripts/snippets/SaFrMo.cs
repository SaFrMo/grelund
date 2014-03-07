using UnityEngine;
using System.Collections;

public static class SaFrMo {

	public static void Move (float rate, Vector3 direction, GameObject go) {
		go.rigidbody.MovePosition (go.transform.position + 
		                        direction * rate);
	}
}
