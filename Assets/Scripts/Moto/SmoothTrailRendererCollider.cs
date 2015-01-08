using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SmoothTrailRendererCollider : MonoBehaviour {
	
	public int time = 3600;
	public float rate = 15.0F;
	private Vector3 lastPos1;
	private Vector3 lastPos2;
	List<GameObject> tail = new List<GameObject>();
	
	void Start () {
		lastPos1 = transform.position;
		lastPos2 = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		createNewTail ();
	}

	void createNewTail(){
		tail.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
		tail[tail.Count-1].name = "Tail" + this.gameObject.name;
		tail[tail.Count-1].transform.localScale = new Vector3(0.05F,2.5F,5F);
		tail[tail.Count-1].transform.rotation = transform.rotation;
		Vector3 tmp;
		if (!transform.position.Equals(lastPos1)) {
			tail [tail.Count - 1].transform.position = transform.position - (transform.forward * 5);
			tmp = transform.position;
		} 
		else {
			tmp = transform.position + (lastPos1 - lastPos2);
			tail [tail.Count - 1].transform.position = tmp - (transform.forward * 5);
		}
		Debug.Log (transform.position + "     " + transform.rotation+ "     " + transform.forward+ "     " + lastPos1+ "     " + lastPos2);
		tail[tail.Count-1].renderer.enabled = false;
		lastPos2 = lastPos1;
		lastPos1 = tmp;
	}

	
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name.Contains("Tail") || col.gameObject.name.Contains("Wall") || col.gameObject.name.Contains("Enemy") || col.gameObject.name.Contains("Moto"))
		{
			foreach(GameObject o in tail){
				Destroy(o);
			}
			print("game over Tail");
			Destroy(gameObject);
		}
	}
}
