using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 6;
	float pipeMax = 1.65f;
	float pipeMin = 0.82f;

	void start(){
		GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
		Collider collider = GetComponent<Collider>();
		foreach (GameObject pipe in pipes) {
			Vector3 pos = collider.transform.position;
			pos.y = Random.Range (pipeMin, pipeMax);
			pipe.transform.position = pos;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Triggered: " + collider.name);
		float widthOfBGObject = ((BoxCollider2D)collider).size.x;
		Vector3 pos = collider.transform.position;
		//pos.x += widthOfBGObject * numBGPanels - widthOfBGObject / 2f;
		pos.x += widthOfBGObject * numBGPanels -0.1f;
		if (collider.tag == "Pipe") {
			pos.y = Random.Range (pipeMin, pipeMax);
		}
		collider.transform.position = pos;
	}

}
