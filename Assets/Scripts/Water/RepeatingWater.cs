using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingWater : MonoBehaviour {

  //private SpriteRenderer waterSprite;
	private BoxCollider2D waterCol;
  private float waterLength; 
	// Use this for initialization
	void Start () {
		//waterSprite = GetComponent<SpriteRenderer>();
		waterCol = GetComponent<BoxCollider2D> ();
		waterLength = waterCol.size.x; // get length of water from scaled tile
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x + waterLength/2 < Camera.main.ViewportToWorldPoint(new Vector3(-.1f,0,0)).x) RepeatWater();
	}

  private void RepeatWater() {
    Vector2 waterOffset = new Vector2(waterLength * 4f, 0);
    transform.position = (Vector2)transform.position + waterOffset;
  }
}
