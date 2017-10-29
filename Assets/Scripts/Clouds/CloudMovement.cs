using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {
  
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(0.2f,1.1f), 0);
	}
	
	void Update () {
    Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
    if (pos.x > 1) Destroy(gameObject);
	}
}
