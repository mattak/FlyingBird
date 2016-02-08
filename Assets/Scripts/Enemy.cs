using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy : MonoBehaviour {
	private Collider2D collider;

	void Start () {
		this.collider = this.GetComponent<Collider2D>();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			SceneManager.LoadScene("Main");
		}
	}
}