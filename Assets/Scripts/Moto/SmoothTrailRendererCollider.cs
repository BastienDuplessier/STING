using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SmoothTrailRendererCollider : MonoBehaviour {
	
	public int time = 3600;
	public float rate = 15.0F;
	private Vector3 lastPos;
	private Vector3 lastRotation;
	private Vector3 decalage = new Vector3();
	List<GameObject> tail = new List<GameObject>();
	
	void Start () {
		StartCoroutine(createNewTail());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator createNewTail(){
		while(true){
			tail.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
			tail[tail.Count-1].name = "Tail";
			tail[tail.Count-1].transform.localScale = new Vector3(0.05F,2.5F,2F);
			tail[tail.Count-1].transform.rotation = transform.rotation;
			tail[tail.Count-1].transform.position = transform.position - (transform.forward*5);
			tail[tail.Count-1].renderer.enabled = false;
			yield return new WaitForSeconds(0.0001F);
		}
	}

	
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name.Contains("Tail") || col.gameObject.name.Contains("Wall"))
		{
			foreach(GameObject o in tail){
				Destroy(o);
			}
			print("game over Tail");
			Destroy(gameObject);
		}
	}
}
