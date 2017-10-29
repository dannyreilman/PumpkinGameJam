using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Random.Range(0.2f,1.1f));

	}

  // Update is called once per frame
  void Update() { }
}
