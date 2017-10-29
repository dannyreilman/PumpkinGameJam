using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullAnim : MonoBehaviour {

	public SpriteRenderer sprite;
	public Rigidbody2D rBody;

	public float delay = 0.5f;
	public float speed = 2f;

	// Use this for initialization
	void Start () {

		rBody = GetComponent<Rigidbody2D> ();
		rBody.velocity = new Vector2(Mathf.Abs(GameController.instance.scrollSpeed)/ speed, 0);
		sprite = GetComponent<SpriteRenderer> ();

		StartCoroutine (Flip ());
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x > Camera.main.ScreenToWorldPoint(Vector3.right * Screen.width).x) Destroy(gameObject);
	}

	IEnumerator Flip(){


		while (!GameController.instance.gameOver){
			sprite.flipY = !sprite.flipY;
			yield return new WaitForSeconds(delay);
		}
	}
}
