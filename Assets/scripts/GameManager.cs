using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameObject PLAYER_1;
	public static GameObject PLAYER_2;

	public static List<GameObject> Enemies = new List<GameObject>();

	void Start () {
		// register players
		PLAYER_1 = GameObject.Find ("Player 1");
		PLAYER_2 = GameObject.Find ("Player 2");
	}

	void Update () {
		// useful counter function
		//print (Enemies.Count);
	}
}
