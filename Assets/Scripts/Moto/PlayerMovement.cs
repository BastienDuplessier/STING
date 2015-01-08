using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement {
	
	// Field of view
	protected float baseFoV = 60F;
	protected float maxFoV = 80F;
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
