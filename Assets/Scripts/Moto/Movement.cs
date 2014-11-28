using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Movement : MonoBehaviour {

	public int speed = 15;

	void Start() {
		controller = new Keyboard ();
	}

	void Update () {
		UpdateKeyboardMovement();
		transform.Translate(Vector3.forward * (speed/10), transform);
	}

	void UpdateKeyboardMovement (){
		if(controller.TurningRight())
			transform.Rotate(Vector3.up*90);
		if(controller.TurningLeft())
			transform.Rotate(Vector3.down*90);
		if(controller.Accelerating())
			speed = 20;
		else if(controller.Slowing())
			speed = 10;
		else
			speed = 15;
	}
	void OnCollisionEnter (Collision col) {
		if(col.gameObject.name.Contains("Wall"))
			Destroy(gameObject);
	}
}
