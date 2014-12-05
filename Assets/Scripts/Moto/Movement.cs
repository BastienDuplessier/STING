using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Movement : MonoBehaviour {

	public float speed = 15F;
	protected Control controller;

	public virtual void Start() {
		DefineControlMethod ();
	}

	public virtual void Update () {
		this.controller.Update();
		this.UpdateMovement();
		transform.Translate(Vector3.forward * (speed/10F), transform);
	}

	public void UpdateMovement (){
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
	
	public virtual void DefineControlMethod() {
		controller = new Keyboard (this);
	}

}
