﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Movement : MonoBehaviour {

	// Acceleration factors
	protected float minSpeed = 15F;
	protected float maxSpeed = 100F;
	protected float lifting = 0.1F; // Smooth the acceleration. 0 > lifting > 1
	protected float const_a; // Needed, don't touch.
	protected int frame_count;

	public float speed;
	protected Control controller;

	public virtual void Start() {
		DefineControlMethod ();
		this.gameObject.AddComponent("SmoothTrailRendererCollider");
		this.frame_count = 0;
		this.speed = this.minSpeed;
    	this.const_a = maxSpeed - minSpeed;
	}

	public virtual void Update () {
		this.controller.Update();
		this.UpdateMovement();
		transform.Translate(Vector3.forward * (speed/10F), transform);
	}

	public void UpdateMovement (){
		if (controller.TurningRight ()) {
			transform.Rotate (Vector3.up * (speed * 0.1F));
		} 
		if (controller.TurningLeft ()) {
			transform.Rotate (Vector3.down * (speed * 0.1F));
		}
		if (controller.Accelerating ()) {
			this.speed = acceleration (frame_count);
			frame_count += 1;
		} else {
			frame_count = 0;
			if(controller.Slowing())
				this.speed = Mathf.Max(this.speed - 1F, this.minSpeed);
			else
				this.speed = Mathf.Max(this.speed - 0.5F, this.minSpeed);
		}

	}
	
	public virtual void DefineControlMethod() {
		controller = new Keyboard (this);
	}

	private float acceleration(int x) {
		return (-this.const_a) * Mathf.Exp (-this.lifting * x) + this.maxSpeed;
	}

}
