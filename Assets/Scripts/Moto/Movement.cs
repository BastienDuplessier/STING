using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Movement : MonoBehaviour {

	// Acceleration factors
	protected float minSpeed = 30F;
    protected float maxSpeed = 60F;
	protected float lifting = 0.05F; // Smooth the acceleration. 0 > lifting > 1
	protected float const_a; // Needed, don't touch.
	public bool collide = true;

	protected int frame_count;
	public float speed;
	protected Control controller;

	public virtual void Start() {
		DefineControlMethod ();
		if(collider)
			this.gameObject.AddComponent("SmoothTrailRendererCollider");
		this.frame_count = 0;
		this.speed = this.minSpeed;
    	this.const_a = maxSpeed - minSpeed;
	}

	public virtual void Update () {
		this.controller.Update();
		this.UpdateMovement();
		this.gameObject.rigidbody.MovePosition ((this.transform.forward * speed) * 0.1F + this.gameObject.rigidbody.position);
	}

	public void UpdateMovement (){
		if (controller.TurningRight ())
			transform.Rotate (Vector3.up * (speed * 0.1F));
		if (controller.TurningLeft ())
			transform.Rotate (Vector3.down * (speed * 0.1F));
		if (controller.Accelerating ()) {
			this.speed = Acceleration (this.frame_count);
			this.frame_count += 1;
		} else {
			if(controller.Slowing())
				this.speed = Mathf.Max(this.speed - 2F, this.minSpeed);
			else
				this.speed = Mathf.Max(this.speed - 0.5F, this.minSpeed);
			this.frame_count = ComputeFrameCount(this.speed);

		}

	}

	public virtual void DefineControlMethod() {
		controller = new Keyboard (this);
	}

	private float Acceleration(int x) {
		return (-this.const_a) * Mathf.Exp (-this.lifting * x) + this.maxSpeed;
	}

	// Acceleration reciprocate (ComputeFrameCount(Acceleration(x)) == x)
	private int ComputeFrameCount(float speed) {
		float result = (Mathf.Log ((speed - this.maxSpeed) / -this.const_a)) / -this.lifting;
		return Mathf.FloorToInt(result);
	}

}
