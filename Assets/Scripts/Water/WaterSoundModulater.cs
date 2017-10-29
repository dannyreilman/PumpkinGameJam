using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundModulater : MonoBehaviour {
    public AudioSource source;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        source.volume = Mathf.Min(0.05f * Mathf.Sin(2 * Time.time) + 0.15f, Time.timeSinceLevelLoad / 5.0f);
    }
}
