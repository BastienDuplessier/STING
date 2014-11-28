using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Movement : MonoBehaviour {

	private float velocity = 2;
	private Vector3 translation = Vector3.zero;
	private Control controller;
	
	void Start() {
		controller = new Keyboard ();
	}

	// Update is called once per frame
	void Update () {
		UpdateMovement ();
	}

	private void UpdateMovement() {
		UpdateVelocity ();
		UpdateTranslation ();
		
		gameObject.transform.Translate (transform.forward * velocity);
	}
	private void UpdateTranslation() {
		translation.x = velocity;
	}


	private void UpdateVelocity() {
		return;
	}
}
