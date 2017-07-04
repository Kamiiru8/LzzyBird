using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour {

	float speed = 0f;

	void FixedUpdate () {
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
	}
}

/*

Rigidbody2D player;

	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		if (player_go == null) {
			Debug.LogError ("Couldn't find object with tag 'Player'!");
			return;
		}
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
		if (rigidbody2D != null) {
			player = player_go.rigidbody2D;
		}
	}

	void FixedUpdate () {
		float vel = player.velocity.x * 0.75f;
		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
	}

*/
