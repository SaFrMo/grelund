using System;
using System.Collections;
using UnityEngine;


public class Scoring : MonoBehaviour
{
	// SCORING SYSTEM
	// IMPLEMENTATION: Attach to Main Camera
	
	// TODO:
	// Adjust enemy spawning rate to reflect current pointsPerSecond
	// Adjust score bonus for having one or both ships onscreen


	public static bool SCORE_ON = true;
	
	// how often score will increase, in seconds
	public static float scoreIncreaseRate = 1f;
	private Timer pIncrease = new Timer (5f, true);
	
	// actual score
	public static float Score = 0;
	
	// add P points per second
	private static float pointsPerInterval = 10f;
	private IEnumerator AddPointsOverTime () {
		while (SCORE_ON) {
			Score += pointsPerInterval;
			yield return new WaitForSeconds (scoreIncreaseRate);//new WaitForSeconds (scoreIncreaseRate);
		}
	}

	// single-shot Add Points - callable on, for example, powerups
	// adds P points (* optional multiplier), ensuring that score goes up
	// over time
	public static void AddPoints (float multiplier = 1f) {
		Score += pointsPerInterval * multiplier;
	}
	
	// called at scene start
	protected IEnumerator Start () {
		StartCoroutine (AddPointsOverTime());
		yield return null;
		//yield return new WaitForSeconds (scoreIncreaseRate);
	}
	
	// called every frame
	protected void Update () {
		if (pIncrease.RunTimer()) {
			// doubles pointsPerSecond every pIncrease seconds
			scoreIncreaseRate *= .5f;
			print (scoreIncreaseRate);
		}

		/*
		if (SCORE_ON) {
			StartCoroutine (AddPointsOverTime ());
			StopCoroutine("AddPointsOverTime");	
		}
		*/
	}
	
	// display score
	private float boxSize = 100f;
	// round the score so the decimals aren't craaaazy
	protected void OnGUI () {
		GUI.Box (new Rect (Screen.width - boxSize, 0, boxSize, boxSize), ((int)Score).ToString());
	}
	
}