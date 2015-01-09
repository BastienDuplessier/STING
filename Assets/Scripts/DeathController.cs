using UnityEngine;
using System.Collections;

public class DeathController : MonoBehaviour {

	private PlayDeathSound player;

	// Use this for initialization
	void Start () {
		this.player = gameObject.GetComponentInChildren<PlayDeathSound> ();
	}

	public void Death() {
		this.player.play();
	}
}
