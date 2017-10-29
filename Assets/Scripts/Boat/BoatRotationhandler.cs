using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRotationhandler : MonoBehaviour {
    public float maxRotation;
    public float scaledRotation;

    private Animator controller;

    private void Start()
    {
        controller = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        controller.SetBool("Go", Input.GetKey(KeyCode.RightArrow) && !GameController.instance.gameOver);

        transform.rotation = Quaternion.Euler(0,0, maxRotation * scaledRotation);
	}
}
