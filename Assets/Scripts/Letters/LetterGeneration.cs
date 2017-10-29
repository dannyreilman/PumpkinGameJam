using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGeneration : MonoBehaviour {

  public GameObject letterObject;
	public char[] letters = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
    'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
		'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
	public char[] etoainshrdlu = { 'E', 'T', 'A', 'O', 'I', 'N',
    'S', 'H', 'R', 'D', 'L'};
	public char[] vowels = { 'A', 'E', 'I', 'O', 'U' };
	public float startDelay;
  private float delay;
  private int layer;
	public float minDelay;
	public float colSize = 10f;

  // Use this for initialization
  void Start() { 
		delay = 2.8f;
    layer = gameObject.layer;
    StartCoroutine(PeriodicSpawn());
	  StartCoroutine(ChangeDelay ());
  }


  IEnumerator PeriodicSpawn() {
    while (!GameController.instance.gameOver) {
      yield return new WaitForSeconds(delay);
      SpawnLetter();
    }
  }

	IEnumerator ChangeDelay(){
		float tempDelay = 3;
		while (!GameController.instance.gameOver) {
			yield return new WaitForSeconds(tempDelay);
			tempDelay += 3f;
			if (delay > minDelay) delay /= 1.15f;
		}
	}
		

  void SpawnLetter(){
    int letterNum = 0;
    bool etoain = false;
		bool vowel = false;

		//Choose subset
    if (Random.Range(0, 10) < 5) {
      //about 50% chance of being etaoin or vowel subset

			//Additional 20% chance to just be vowel
			if (Random.Range (0, 5) == 1) {
				letterNum = Random.Range (0, 5);
				vowel = true;

			} else {
				letterNum = Random.Range(0, 11);
				etoain = true;
			}
    }
		else letterNum = Random.Range (0, 26);
    
    //Create letter instance
    GameObject spawned = Instantiate(letterObject, this.transform);

    //Set text
    char letterText;
		if (etoain) letterText = etoainshrdlu [letterNum];
		else if (vowel) letterText = vowels [letterNum];
    else letterText = letters[letterNum];
    spawned.GetComponent<TextMesh>().text = letterText.ToString();

		spawned.GetComponent<LetterMovement> ().letter = letterText;

		float yOffset = Random.Range(-3.5f, 2.5f);

		spawned.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, 0f);
		spawned.layer = 31;

		var renderer = spawned.GetComponent<TextMesh>();

		renderer.offsetZ = 1;
    }
}
