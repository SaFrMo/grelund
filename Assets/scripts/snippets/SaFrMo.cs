using UnityEngine;
using System.Collections;

public static class SaFrMo {

	static System.Random rand = new System.Random();


	/// <summary>
	/// Move the specified GameObject in the specified direction at the specified rate. Requires a Rigidbody attached to the GameObject in question.
	/// </summary>
	/// <param name="rate">Rate.</param>
	/// <param name="direction">Direction.</param>
	/// <param name="go">Go.</param>
	public static void MoveObject (float rate, Vector3 direction, GameObject go) {
		go.rigidbody.MovePosition (go.transform.position + 
		                        direction * rate * Time.deltaTime);
	}

	/// <summary>
	/// Gets a random true/false value (boolean value).
	/// </summary>
	/// <returns><c>true</c>, if random bool was gotten, <c>false</c> otherwise.</returns>
	public static bool GetRandomBool() {
		return (rand.NextDouble() > 0.5);
	}
}
