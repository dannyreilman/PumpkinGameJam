using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTrayDisplay : MonoBehaviour {

    Text textBox;
    BoatController boat;
    bool isBlinking = false;
    Animator controller;

    // Use this for initialization
    void Start() {
        textBox = GetComponent<Text>();
        controller = GetComponent<Animator>();
        boat = GameObject.Find("BoatWithRocking").GetComponentInChildren<BoatController>();
        textBox.text = "Letters Collected:\n";
    }

    // Update is called once per frame
    void Update() {
        if (!isBlinking)
        {
            if (textBox.text != "Letters Collected:\n" + boat.letterTray.currString.ToUpper())
            {
                textBox.text = "Letters Collected:\n" + boat.letterTray.currString.ToUpper();
                controller.SetTrigger("Bounce");
            }
        }
    }

    public void Force()
    {
        Update();
    }

  public IEnumerator BB() {
    while (isBlinking) {
      textBox.color = Color.red;
      yield return new WaitForSeconds(0.5f);
      textBox.color = Color.white;
      yield return new WaitForSeconds(0.5f);
    }
  }

  public IEnumerator BG() {
    while (isBlinking) {
      textBox.color = Color.green;
      yield return new WaitForSeconds(0.5f);
      textBox.color = Color.white;
      yield return new WaitForSeconds(0.5f);
    }
  }

  public IEnumerator BT() {
    isBlinking = true;
    yield return new WaitForSeconds(0.5f);
    textBox.text = "Letters Collected:\n";
    isBlinking = false;
  }

  public void BlinkGood() {
    StartCoroutine(BT());
    StartCoroutine(BG());
  }

  public void BlinkBad() {
    StartCoroutine(BT());
    StartCoroutine(BB());
  }
}
