using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausedScreen : MonoBehaviour {
  Text textBox;

	void Start () {
    textBox = this.GetComponent<Text>();
  }
	
	void Update () {
    if (GameController.instance.paused)
      textBox.text = "PAUSED:\nHit P to resume, or Esc to exit to main menu";
    else textBox.text = "";
	}
}
