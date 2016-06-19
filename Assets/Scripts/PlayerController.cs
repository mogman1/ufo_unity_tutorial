using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public int object_count;

	private Rigidbody2D rb2d;

	void Start() {
		object_count = 0;
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			object_count++;
			other.gameObject.SetActive (false);
		}
	}
}
