using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGeneration : MonoBehaviour {

	public GameObject fishObject;
	public float delay;

	// Use this for initialization
	void Start () {
		StartCoroutine(PeriodicSpawn(delay));
	}

	IEnumerator PeriodicSpawn(float delay){
		while (true)
		{
			yield return new WaitForSeconds(delay);
			spawnFish();
		}
	}

	void spawnFish(){
		GameObject spawned = Instantiate (fishObject, this.transform);

		spawned.transform.position = new Vector2 (transform.position.x, transform.position.y);
		spawned.GetComponent<FishMovement> ().yOffset = transform.position.y + Random.Range(-1f,1f);

		float scaleMult = Random.Range (1f, 1.75f);

		spawned.transform.localScale *= scaleMult;
		spawned.GetComponent<Rigidbody2D> ().velocity = new Vector2 (GameController.instance.scrollSpeed / 2f, 0) * scaleMult * Random.Range (.5f, 2.5f);

		delay = Random.Range(10f, 15f);
	
	}

}
