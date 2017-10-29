using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {

	public float yOffset;
	private Rigidbody2D rBody;
	private float yMult;
  
	void Start () {
		rBody = this.GetComponent<Rigidbody2D> ();
		yMult = Random.Range (.9f, 1.25f);
	}
	
	void Update () {
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		if (pos.x < -1) Destroy(gameObject);
		transform.position = new Vector2(transform.position.x, 
      yMult * 1.5f * Mathf.Sin (2 * Time.time) + yOffset);
	}
}
