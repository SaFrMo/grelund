using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameObject PLAYER_1;
	public static GameObject PLAYER_2;

	void Start () {
		// register players
		PLAYER_1 = GameObject.Find ("Player 1");
		PLAYER_2 = GameObject.Find ("Player 2");
	}
}
