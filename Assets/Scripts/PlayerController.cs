using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text victoryText;

	private int count;
	private Rigidbody2D rb2d;

	void Start() {
		count = 0;
		rb2d = GetComponent<Rigidbody2D> ();
		SetCountText ();
		victoryText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			count++;
			other.gameObject.SetActive (false);
			SetCountText ();
		}
	}

	void SetCountText() {
		countText.text = "Score: " + count.ToString ();
		if (count >= 12) {
			victoryText.text = "A winner is you!";
		}
	}
}
