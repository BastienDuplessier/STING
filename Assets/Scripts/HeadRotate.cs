using UnityEngine;
using System.Collections;

public class HeadRotate : MonoBehaviour {

	public int rotated = 0;
	private SightReducer sightScript;

	void Start() {
		this.sightScript = this.GetComponentInChildren<SightReducer> ();
	}

	// Update is called once per frame
	void Update () {;
		UpdateSight ();
		// Rotate camera
		Vector3 rotation = Vector3.zero;
		if (Input.GetKey (KeyCode.Q) || (rotated > 0 && !Input.GetKey(KeyCode.D))) {
			rotation.y = -1F;
			rotated -= 1;
		}
		else if(Input.GetKey(KeyCode.D) || rotated < 0) {
			rotation.y = 1F;
			rotated += 1;
		}

		gameObject.transform.Rotate (rotation);
	}

	private void UpdateSight() {
		if(rotated != 0)
			this.sightScript.HideSight();
		else
			this.sightScript.ShowSight();
	}
}
