using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {
  public Rigidbody2D rigid;
  Transform leftBorderCheck;
  Transform rightBorderCheck;
  Vector2 playerPos;
  Vector2 world;
  BoxCollider2D collider;
  Animator anim;
	ChangingHeight heightScript;
  LetterTrayDisplay trayDisplay;

	public LetterTray letterTray;

	public float yValue;

  public float moveSpeed;
	public int testScore;
  float offset;


  public AudioSource boatSound;
  public AudioSource pitched;
  public AudioClip successStinger;
  public AudioClip failBeep;
  public AudioClip letterGrab;

    // Use this for initialization
  void Start () {
    rigid = this.GetComponent<Rigidbody2D>();
    collider = this.GetComponent<BoxCollider2D>();
    offset = collider.bounds.size.x / 2;
		heightScript = GetComponent<ChangingHeight> ();
		letterTray = GetComponent<LetterTray> ();
    anim = GetComponent<Animator>();
    boatSound = GetComponent<AudioSource>();
    trayDisplay = GameObject.Find("LetterTray Display").GetComponent<LetterTrayDisplay>();
  }
	
	// Update is called once per frame
	void Update () {
    float leftPos = Camera.main.WorldToScreenPoint(transform.position - Vector3.right * offset).x;
    float rightPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.right * offset).x;
    float newPos = 0;

    if (leftPos < 0) {
      newPos = Camera.main.ScreenToWorldPoint(Vector3.zero).x + offset;
    }
    else if (rightPos > Screen.width) {
      newPos = Camera.main.ScreenToWorldPoint(Vector3.right * Screen.width).x - offset;
    }
    else newPos = transform.position.x;

    transform.position = new Vector3(newPos, transform.position.y, 0);

        //Clear word
    if (Input.GetKeyDown(KeyCode.Space) && !GameController.instance.gameOver && letterTray.currString.Length > 0){
      string word = letterTray.currString;
      if(letterTray.ClearWord()){
        trayDisplay.BlinkGood();
        boatSound.PlayOneShot(successStinger);
        GameController.instance.score += ScoreWord(word);
      } else {
        trayDisplay.BlinkBad();
        boatSound.PlayOneShot(failBeep);
        GameController.instance.lives -= 1;
      }
    }
  }

  int ScoreWord(string word) {
    return Mathf.FloorToInt(Mathf.Exp(word.Length - 1));
  }


	void OnCollisionEnter2D (Collision2D col) {
		Destroy(col.gameObject);
    if (col.collider.tag == "Letter" && !GameController.instance.gameOver) {
      if (!(letterTray.AddLetter(col.collider.GetComponent<LetterMovement>().letter))) {
                //Only runs when no word can be made
                trayDisplay.Force();
                trayDisplay.BlinkBad();
        boatSound.PlayOneShot(failBeep);
        --GameController.instance.lives;
        if(letterTray.ClearWord())
        {
            Debug.Log("Uh oh");
        }
      }
      else {
        //Picked up a good letter
        pitched.pitch = (1.0f - 1.0f / (letterTray.currString.Length + 1)) * 2.0f + 0.1f;
        pitched.Play();
      }
    }
	}

  private void FixedUpdate() {
    if (!GameController.instance.gameOver) {
      if (Input.GetKey(KeyCode.RightArrow)) {
        if(heightScript.landed)
            rigid.velocity = new Vector2(moveSpeed, 0);
        else
            rigid.velocity = new Vector2(moveSpeed * 1.25f, 0);

        anim.SetBool("isRight", true);
      }
      else {
        rigid.velocity = new Vector2(GameController.instance.scrollSpeed * 1.1f, 0);
        anim.SetBool("isRight", false);
      }
    }
    else  anim.SetBool("isRight", false);
  }
}
