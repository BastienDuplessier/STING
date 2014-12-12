using System.Collections.Generic;
using UnityEngine;

public class TrailRendererCollider : MonoBehaviour {
	
	public int time = 3600;
	public float rate = 15.0F;
	private Vector3 lastPos;
	private Vector3 lastRotation;
	private Vector3 LastDecalage = new Vector3();
	private Vector3 decalage = new Vector3();
	List<GameObject> tail = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
		/*lastPos = transform.position;
		lastRotation = transform.eulerAngles;
		createNewTail(lastRotation);*/
	}
	
	// Update is called once per frame
	void Update () {
		/*if (!transform.eulerAngles.Equals(lastRotation)) {
			transform.Translate(Vector3.forward * 2, transform);
			lastRotation = transform.eulerAngles;
			createNewTail(lastRotation);
		} else {
			tail [tail.Count - 1].transform.localScale += (transform.position - lastPos);
			tail [tail.Count - 1].transform.position += (transform.position - lastPos) / 2;
		}
		lastPos = transform.position;*/
	}

	void createNewTail(Vector3 rotation){
		tail.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
		if (tail.Count == 2) {
			tail[tail.Count-2].transform.position -= decalage;
		}
		if (tail.Count >= 3) {
			tail[tail.Count-2].transform.position -= (decalage / 2 );
			tail[tail.Count-2].transform.localScale -= decalage;
		}
		if (rotation.y > 315F || rotation.y <= 45F) {
			decalage = new Vector3 (0F, -0.25F, -3.1F);
			LastDecalage = new Vector3 (0F, 0F, -0.4F);
		} else if (rotation.y > 45F && rotation.y <= 135F) {
			decalage = new Vector3 (-3.1F, -0.25F, 0F);
			LastDecalage = new Vector3 (-0.4F, 0F, 0F);
		} else if (rotation.y > 135F && rotation.y <= 225F) {
			decalage = new Vector3 (0F, -0.25F, 3.1F);
			LastDecalage = new Vector3 (0F, 0F, 0.4F);
		} else if (rotation.y > 225F && rotation.y <= 315F) {
			decalage = new Vector3 (3.1F, -0.25F, 0F);
			LastDecalage = new Vector3 (0.4F, 0F, 0F);
		}
		tail[tail.Count-1].name = "Tail";
		tail[tail.Count-1].transform.localScale = new Vector3(0.05F,2.5F,0.05F) - LastDecalage;
		tail[tail.Count-1].transform.position = transform.position + decalage + (LastDecalage / 2 );
		tail[tail.Count-1].renderer.material = gameObject.renderer.material;
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
