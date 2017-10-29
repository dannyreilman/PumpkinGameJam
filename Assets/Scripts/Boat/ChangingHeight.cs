using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingHeight : MonoBehaviour {
    public static float LAUNCH_SPEED = 10.0f;

    public float boyancySpeed;
    public float accel;

    private bool launching;
    public bool ready;
    public bool landed;

    private float goalY;
    private float yVelocity;
    public float currentY;

    private static float MARGIN = 0.1f;
    private static float VEL_MARGIN = 2.5f;


    // Update is called once per frame
    void FixedUpdate()
    {
        goalY = ScrollingWater.Y_VALUE + ScrollingWater.WATER_OFFSET + .125f;

        if (launching)
        {
            landed = false;
            currentY = this.transform.localPosition.y + yVelocity * Time.deltaTime;
        }
        else if (landed)
        {
            yVelocity = 0;
            currentY = goalY;
        }
        else
        {
            //Accelerate towards middle
            currentY = this.transform.localPosition.y + yVelocity * Time.deltaTime;

            if (transform.localPosition.y > goalY)
            {
                yVelocity -= accel;
                if (yVelocity < -25.0f)
                {
                    yVelocity = -25.0f;
                }
            }

            if (transform.localPosition.y < goalY)
            {
                yVelocity += 4 * accel;
                if (yVelocity > 2.0f * Mathf.Cos(2 * Time.time) + boyancySpeed)
                {
                    yVelocity = 2.0f * Mathf.Cos(2 * Time.time) + boyancySpeed;
                }

            }
        }

        //Land if in margin and slow
        if (Mathf.Abs(transform.localPosition.y - goalY) < MARGIN
            && Mathf.Abs(yVelocity) < VEL_MARGIN && !launching && !landed)
        {
            yVelocity = 0;
            currentY = goalY;
            landed = true;
        }


        this.transform.localPosition = new Vector3(this.transform.localPosition.x,
                currentY, this.transform.localPosition.z);

        ready = transform.localPosition.y <= goalY;
    }

    void Update()
    {
        if (landed)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x,
                ScrollingWater.Y_VALUE + ScrollingWater.WATER_OFFSET + .125f, this.transform.localPosition.z);
        }
    }

    public void SetVelocity(float fin)
    {
        yVelocity = fin;
    }

    public void Launch()
    {
        launching = true;
    }

    public void StopLaunching()
    {
        launching = false;
    }
}
