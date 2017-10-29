using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour {

	public GameObject cloudObject;
	public Sprite[] clouds;
	public float delay;

	void Start(){
		StartCoroutine(PeriodicSpawn(delay));
	}

	IEnumerator PeriodicSpawn(float delay){
		while (!GameController.instance.gameOver)
		{
			yield return new WaitForSeconds(delay);
			spawnCloud();
		}
	}


	void spawnCloud(){
		GameObject spawned = Instantiate(cloudObject, this.transform);

		int randCloud = Random.Range(0, 2);

		spawned.GetComponent<SpriteRenderer>().sprite = (clouds [randCloud]);

		spawned.transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-4.25f, .75f));

		float scaleMult = Random.Range (1.25f, 2.5f);

		spawned.transform.localScale *= scaleMult;
		spawned.GetComponent<Rigidbody2D> ().velocity *= scaleMult*.8f;
		delay = Random.Range(2f, 3.5f);
	}
}