using UnityEngine;
using System.Collections;

public class SightReducer : MonoBehaviour {

	private RectTransform rTransform;
	private float baseScaleX = 0.5F;
	private float minScaleX = 0.12F;
	private float rangeX;
	
	// Use this for initialization
	void Start () {
		this.rTransform = gameObject.GetComponent<RectTransform> ();
		rangeX = Mathf.Abs(baseScaleX - minScaleX);
	}
	
	public void UpdateHiding(float rate) {
		float newScaleX = this.baseScaleX - (rate * this.rangeX);
		rTransform.localScale = new Vector3 (newScaleX, 1F, 1F);
	}
}
