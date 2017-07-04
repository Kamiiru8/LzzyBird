using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {

	//Vector3 velocity = Vector3.zero;
	public float flapSpeed = 100f;
	public float forwardSpeed = 1f;
	bool didFlap = false;
	public bool death = false;
	float deathCooldown;
	Animator animator;
	//public float maxSpeed = 5f;
	//public Vector3 gravity;
	//public Vector3 flapVelocity;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();
		if (animator == null) {
			Debug.LogError ("Didn't find animator");
		}
	}

	// do graphics & input updates here
	void Update(){
		if (death) {
			deathCooldown -= Time.deltaTime;
			if (deathCooldown <= 0) {
				if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
					Application.LoadLevel (Application.loadedLevel);
				}
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				didFlap = true;
			}
		}
	}
	
	// do physics engine updates here
	void FixedUpdate () {
		
		/*velocity.x = forwardSpeed;
		//velocity += gravity * Time.deltaTime;
		if (didFlap == true) {
			didFlap = false;
			if (velocity.y < 0)
				velocity.y = 0;
			velocity += flapVelocity;
		}
		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
		transform.position += velocity * Time.deltaTime;
		//rigidbody2D.AddForce(velocity);
		float angle = 0;
		if (velocity.y < 0) {
			angle = Mathf.Lerp (0, -90, -velocity.y / maxSpeed);
		}
		transform.rotation = Quaternion.Euler(0, 0, angle); */

		if (death)
			return;
		Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D> ();
		if (rigidbody2D != null) {
			rigidbody2D.AddForce (Vector2.right * forwardSpeed);
			if (didFlap) {
				rigidbody2D.AddForce (Vector2.up * flapSpeed);
				animator.SetTrigger ("DoFlap");
				didFlap = false;
			}
			if (rigidbody2D.velocity.y > 0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				float angle = Mathf.Lerp (0, -90, -rigidbody2D.velocity.y / 3f);
				transform.rotation = Quaternion.Euler (0, 0, angle);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		animator.SetTrigger ("Death");
		death = true;
		deathCooldown = 0.5f;
	}	
}
