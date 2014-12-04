using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Movement : MonoBehaviour {

	public float speed = 15F;
	private Control controller;

	void Start() {
		controller = new Keyboard ();
	}

	void Update () {
		UpdateKeyboardMovement();
		transform.Translate(Vector3.forward * (speed/10F), transform);
	}

	void UpdateKeyboardMovement (){
		speed = 15F;
		if (controller.TurningRight ()) {
			transform.Rotate (Vector3.up * 90);
		} 
		else if (controller.TurningLeft ()) {
			transform.Rotate (Vector3.down * 90);
		}
		else if(controller.Accelerating())
			speed = 20F;
		else if(controller.Slowing())
			speed = 10F;

	}
}
