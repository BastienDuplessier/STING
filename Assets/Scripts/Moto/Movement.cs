using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private float velocity = 2;
	private Vector3 translation = Vector3.zero;

	// Update is called once per frame
	void Update () {
		UpdateMovement ();
	}

	private void UpdateMovement() {
		UpdateVelocity ();
		UpdateTranslation ();


		gameObject.transform.Translate (translation);
	}
	private void UpdateTranslation() {
		translation.x = velocity;
	}


	private void UpdateVelocity() {
		return;
	}
}
