using UnityEngine;
using System.Collections;

public class TrailRendererCollider : MonoBehaviour {
	
	public int time = 3600;
	public float rate = 15.0F;
	private Vector3 decalage;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(DropTrailCollider());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator DropTrailCollider(){
		while(true){
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.name = "Tail";
			cube.transform.localScale = new Vector3(0.1F,8F,3F);
			if(transform.eulerAngles.y > 315F || transform.eulerAngles.y <= 45F)
				decalage = new Vector3(0F,0F,-6F);
			else if(transform.eulerAngles.y > 45F && transform.eulerAngles.y <= 135F)
				decalage = new Vector3(-6F,0F,0F);
			else if(transform.eulerAngles.y > 135F && transform.eulerAngles.y <= 225F)
				decalage = new Vector3(0F,0F,6F);
			else if(transform.eulerAngles.y > 225F && transform.eulerAngles.y <= 315F)
				decalage = new Vector3(6F,0F,0F);
			cube.transform.position = transform.position + decalage;
			cube.transform.rotation = transform.rotation;
			yield return new WaitForSeconds(1.0F / rate);
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name.Contains("Tail"))
		{
			print("game over Tail");
			Destroy(gameObject);
		}
	}
}
