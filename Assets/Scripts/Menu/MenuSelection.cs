using UnityEngine;
using System.Collections;

public class MenuSelection : MonoBehaviour {
	
	private TextSelection newGame;
	private TextSelection exitGame;


	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.rotation.y < -0.1)
			newGame.Select ();
		else if (Camera.main.transform.rotation.y > 0.1)
			exitGame.Select ();
		else {
			newGame.Unselect ();
			exitGame.Unselect ();
		}
		// Rotate camera
		Vector3 rotation = Vector3.zero;
		if(Input.GetKey(KeyCode.LeftArrow))
			rotation.y = -0.5F;
		else if(Input.GetKey(KeyCode.RightArrow))
			rotation.y = 0.5F;
		Camera.main.transform.Rotate (rotation);

		// Validate
		if (Input.GetKey(KeyCode.Return))
			loadChoice ();
	}

	public void notify(TextSelection behaviour, string text) {
		if(text.Equals("New Game"))
			newGame = behaviour;
		else if (text.Equals("Exit Game"))
			exitGame = behaviour;
	}

	private void loadChoice() {
		if (this.newGame.Selected ())
			Application.LoadLevel ("main_scene");
		else if (this.exitGame.Selected ())
			Application.Quit();
	}
}
