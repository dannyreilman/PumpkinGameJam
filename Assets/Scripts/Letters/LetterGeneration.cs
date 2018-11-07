using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGeneration : MonoBehaviour {

  public GameObject letterObject;
	public char[] letters = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
    'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
		'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
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
		List<char> options = LetterTray.instance.GetValid();
		char letterText = '\0';
		if(options.Count > 0)
		{
			letterText = options[Random.Range(0, options.Count)];
		}
		else
		{
			letterText = letters[Random.Range(0,26)];
		}
    //Create letter instance
    GameObject spawned = Instantiate(letterObject, this.transform);

    spawned.GetComponent<TextMesh>().text = letterText.ToString();

		spawned.GetComponent<LetterMovement> ().letter = letterText;

		float yOffset = Random.Range(-3.5f, 2.5f);

		spawned.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, 0f);
		spawned.layer = 31;

		var renderer = spawned.GetComponent<TextMesh>();

		renderer.offsetZ = 1;
    }
}
