using UnityEngine;
using System.Collections;

public class MatchingGUISize : MonoBehaviour {

	/*
	 * Attach to a cube that you want a GUIBox to lay directly over.
	 * Modify children in implementation as you see fit.
	 */

	protected GUIContent content = new GUIContent ("test");

	protected void OnGUI () {

		GUI.Box (new Rect (Camera.main.WorldToScreenPoint (renderer.bounds.min).x,
	                       Camera.main.WorldToScreenPoint (-transform.position - renderer.bounds.extents).y,
		                   Camera.main.WorldToScreenPoint (renderer.bounds.max).x - Camera.main.WorldToScreenPoint(renderer.bounds.min).x + 1f,
		                   Camera.main.WorldToScreenPoint (renderer.bounds.max).y - Camera.main.WorldToScreenPoint(renderer.bounds.min).y + 1f), content);

	}
}
