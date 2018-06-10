using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviours : MonoBehaviour {
	Rigidbody2D rb2d;
	public VirtualJoystick moveJoystick;
	Vector2 move;
	Animator anim;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//X axes of movement
		move = new Vector2 (moveJoystick.InputDirection.x, moveJoystick.InputDirection.y);
		rb2d.velocity = new Vector2 (move.x * 4, move.y*4);

		if (move != Vector2.zero) {
			anim.SetBool ("isMoving", true);
			anim.SetFloat ("vel_x", move.x);
			anim.SetFloat ("vel_y", rb2d.velocity.y);
		} else {
			anim.SetBool ("isMoving", false);
		}

		float velocity_y = rb2d.velocity.y;

		if (velocity_y > 5) {
			velocity_y = 5;
		}
		//rb2d.velocity = Vector2.zero;

		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Monster") {
			Debug.Log ("You touch Monster!");
			int X = Random.Range (0, 4);
			Debug.Log ("" + X);
			if (X == 0) {
				SceneManager.LoadScene ("Quest1");
			} else if (X == 1) {
				SceneManager.LoadScene ("Quest2");
			} else if (X == 2) {
				SceneManager.LoadScene ("Quest3");
			} else if (X == 3) {
				SceneManager.LoadScene ("Quest4");
			}
		}

	}

}
