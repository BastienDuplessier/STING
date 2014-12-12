using UnityEngine;
using System.Collections.Generic;

public class SmoothTrailRendererCollider : MonoBehaviour
{
	List<Vector3> tail = new List<Vector3>();
	RaycastHit hit;
	
    void Start(){
		
    }
	
    void Update(){
		tail.Add(this.transform.position);
		TestHit();
    }
	
	void TestHit(){
		int i = tail.Count;
		while (i > 1) {
			if (Physics.Linecast(tail[i-1], tail[i-2], out hit)){
				GameOver(hit.collider);
			}
			i--;
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name.Contains("Wall"))
		{
			GameOver(this.collider);
		}
	}
	
	void GameOver(Collider collider){
		print("game over " + collider.name);
		Destroy(collider.gameObject);
	}
}