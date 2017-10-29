using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour {
    public ChangingHeight boatHeight;

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameController.instance.gameOver && Input.GetKeyDown(KeyCode.UpArrow) && boatHeight.ready)
        {
            animator.SetTrigger("Jump");
            boatHeight.SetVelocity(ChangingHeight.LAUNCH_SPEED + 4.0f * Mathf.Cos(2 * Time.time));
        }

        animator.SetBool("Ready", boatHeight.ready);
    }

    public void StopLaunching()
    {
        boatHeight.StopLaunching();
    }

    public void Launch()
    {
        boatHeight.Launch();
    }

}
