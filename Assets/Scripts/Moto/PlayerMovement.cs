﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement {
	
	// Field of view
	protected float baseFoV = 60F;
	protected float maxFoV = 100F;
	// Sight reducers
	private SightReducer hideLeft;
	private GameObject hideRight;

	public override void Start() {
		base.Start ();
		this.hideLeft = this.gameObject.GetComponentInChildren<SightReducer> ();
	}

	// Update is called once per frame
	public override void Update () {
		base.Update ();
		this.UpdateFieldOfView ();
		this.UpdateSightReducing ();
		
		// Rotate camera
		Vector3 rotation = Vector3.zero;
		if(Input.GetKey(KeyCode.Q))
			rotation.y = -1F;
		else if(Input.GetKey(KeyCode.D))
			rotation.y = 1F;
		Camera.main.transform.Rotate (rotation);

	}
	
	private void UpdateFieldOfView () {
		float newFieldOfView = this.baseFoV;
		float rate = (this.speed - this.minSpeed) / this.const_a;
		newFieldOfView += (this.maxFoV - this.baseFoV) * rate;
		Camera.main.fieldOfView = newFieldOfView;
	}

	private void UpdateSightReducing() {
		float rate = (this.speed - this.minSpeed) / this.const_a;
		this.hideLeft.UpdateHiding (rate);
	}

	void OnDestroy() {
		Application.LoadLevel ("title_scene");
	}
}
