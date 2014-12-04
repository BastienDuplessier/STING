using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Movement : MonoBehaviour {

	public float speed = 15F;
	protected Control controller;

	void Start() {
		DefineControlMethod ();
	}

	public virtual void DefineControlMethod() {
		controller = new Keyboard ();
	}

	void Update () {
		UpdateKeyboardMovement();
		transform.Translate(Vector3.forward * (speed/10F), transform);
	}

	void UpdateKeyboardMovement (){
		if (controller.TurningRight ()) {
			transform.Rotate (Vector3.up * 90);
		}
		if (controller.TurningLeft ()) {
			transform.Rotate (Vector3.down * 90);
		}
		if(controller.Accelerating())
			speed = 20F;
		else if(controller.Slowing())
			speed = 10F;
		else
			speed = 15F;
	}
}
