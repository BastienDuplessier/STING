using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int speed = 15;
	// Use this for initialization
	void Start () {
	}
	void Update () {
		UpdateKeyboardMovement();
		transform.Translate(Vector3.forward * (speed/10), transform);
	}
	void UpdateKeyboardMovement (){
		if(Input.GetKeyDown(KeyCode.RightArrow))
			transform.Rotate(Vector3.up*90);
		if(Input.GetKeyDown(KeyCode.LeftArrow))
			transform.Rotate(Vector3.down*90);
		if(Input.GetKey(KeyCode.UpArrow))
			speed = 20;
		else if(Input.GetKey(KeyCode.DownArrow))
			speed = 10;
		else
			speed = 15;
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name.Contains("Wall"))
		{
			print("game over Wall");
			Destroy(gameObject);
		}
	}
}
