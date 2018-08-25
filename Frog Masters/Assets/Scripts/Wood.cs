using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour {

	public Rigidbody2D rb;
	public bool right;

	public float speed;
	public bool collideFrog;

	void Start () {
		collideFrog = false;
		speed = 1.0f; 
	}

	void FixedUpdate () {
		if (right) {
			rb.velocity = new Vector2 (speed, 0f);
		} else {
			rb.velocity = new Vector2 (-speed, 0f);
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			collideFrog = true;
		}
		if (other.tag == "Destroy") {
			if (collideFrog == true) {
				gameObject.GetComponent<Frog> ().respawn ();
			}
			Destroy (gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			collideFrog = false;
		}
	}
}
