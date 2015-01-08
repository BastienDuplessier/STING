using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class EnemyMovement : Movement
{
	protected new float maxSpeed = 30;

	public override void DefineControlMethod() {
		this.controller = new IAControl (this, gameObject, this.maxSpeed);
	}

	public override void Update() {
		base.Update ();
		this.controller.Update ();
	}
}

