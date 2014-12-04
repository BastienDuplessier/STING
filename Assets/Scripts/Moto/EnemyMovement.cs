using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class EnemyMovement : Movement
{
	public override void DefineControlMethod() {
		this.controller = new IAControl (this, gameObject);
	}
}

