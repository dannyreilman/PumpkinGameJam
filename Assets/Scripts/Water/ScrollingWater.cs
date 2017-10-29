using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingWater : MonoBehaviour{
  public static float WATER_HEIGHT = -5.5f;
	public static float Y_VALUE;
  public static float WATER_OFFSET;
	public int counterA, counterB;
  private Rigidbody2D rigid;

  void Start() {
    rigid = this.GetComponent<Rigidbody2D>();
		rigid.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
    WATER_OFFSET = gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2;
  }
  
  void Update() {
    Y_VALUE = 2*Mathf.Sin (2 * Time.time) + WATER_HEIGHT;
		this.transform.position = new Vector3(this.transform.position.x, Y_VALUE, this.transform.position.z);

  }
}
