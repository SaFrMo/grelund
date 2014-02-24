using UnityEngine;
using System.Collections;

public class PawnBehavior : MonoBehaviour {

	float minSize = .5f;
	float maxSize = 2f;

	float currentScale;

	float rate = 1f;

	bool expanding = true;

	void Breathe() {
		if (currentScale < maxSize && expanding) {
			currentScale += rate * Time.deltaTime;
		}
		else if ((currentScale >= maxSize && expanding) || (currentScale <= minSize && !expanding)) {
			expanding = !expanding;
		}
		else if (currentScale > minSize && !expanding) {
			currentScale -= rate * Time.deltaTime;
		}
	}

	void Start() {
		transform.localScale *= minSize;
		currentScale = minSize;
	}

	void Update () {
		Breathe();
		transform.localScale = Vector3.one * currentScale;
	}
}
