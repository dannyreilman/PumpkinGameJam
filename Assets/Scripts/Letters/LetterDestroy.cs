using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.collider.tag == "Letter") Destroy(other.gameObject);
  }
}
