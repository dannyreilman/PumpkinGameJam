using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullGeneration : MonoBehaviour {

	public GameObject seagullObj;
	public float delay;

	void Start(){
		StartCoroutine(PeriodicSpawn(delay));
	}

	IEnumerator PeriodicSpawn(float delay){
		while (!GameController.instance.gameOver)
		{
			yield return new WaitForSeconds(delay);
			spawnSeagull();
		}
	}


	void spawnSeagull(){
		GameObject spawned = Instantiate(seagullObj, transform);

		spawned.transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-.7f, 1f));

		delay = Random.Range(3f, 5f);
	}
}