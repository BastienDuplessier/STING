using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextSelection : MonoBehaviour {
	
	private bool selected;
	private MenuSelection parent;

	// Use this for initialization
	void Start () {
		this.selected = false;
		this.parent = this.gameObject.GetComponentInParent<MenuSelection> ();
		this.parent.notify (this, this.gameObject.GetComponent<Text> ().text);
	}

	public bool Selected() {
		return this.selected;
	}

	public void Select() {
		this.selected = true;
		this.gameObject.GetComponent<Text> ().color = Color.white;
	}

	public void Unselect() {
		this.selected = false;
		this.gameObject.GetComponent<Text> ().color = Color.gray;
	}
}
