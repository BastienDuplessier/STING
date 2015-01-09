using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class EnemyMovement : Movement
{
	public override void DefineControlMethod() {
		this.controller = new IAControl (this, gameObject, this.maxSpeed);
	}

	public override void Update() {
		base.Update ();
		this.controller.Update ();
		if (speed > maxSpeed * 0.60)
			((IAControl)this.controller).TooFast ();
		else
			((IAControl)this.controller).SpeedIsOk ();
	}
}

