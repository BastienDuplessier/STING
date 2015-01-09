using UnityEngine;
using System.Collections;

public class PlayDeathSound : MonoBehaviour {
	private AudioSource deathSound;

	// Use this for initialization
	void Start () {
		this.deathSound = gameObject.GetComponent<AudioSource> ();
	}

	public void play() {
		this.deathSound.Play ();
	}
}
