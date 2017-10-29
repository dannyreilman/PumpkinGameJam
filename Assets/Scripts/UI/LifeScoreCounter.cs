using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScoreCounter : MonoBehaviour {

  Text textBox;

	// Use this for initialization
	void Start () {
    textBox = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
    textBox.text = "Lives: " + GameController.instance.lives + "\nScore: "
      + GameController.instance.score;
	}
}
