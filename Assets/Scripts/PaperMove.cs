using UnityEngine;
using System.Collections;
using System;

public class PaperMove : MonoBehaviour
{

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;


    [SerializeField]
    private float acelerationV;
    [SerializeField]
    private float decelerationV;
    private float speedX;
    private float speedY;

    void Update()
    {
        SpeedUp();
        transform.Translate(new Vector2(speedX, speedY));
        speedX = deceleration(speedX); speedY = deceleration(speedY);
    }

    void SpeedUp()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            speedY += acelerationV * Time.deltaTime;

        }
        if (Input.GetAxis("Vertical") < 0)
        {
            speedY -= acelerationV * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            speedX += acelerationV * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            speedX -= acelerationV * Time.deltaTime;
        }
    }
    float deceleration(float axis)
    {
        if (axis != 0)
        {
            if (axis > 0)
                axis -= decelerationV * Time.deltaTime;
            if (axis < 0)
                axis += decelerationV * Time.deltaTime;
        }
        if (axis > -0.001f && axis < 0.001f)
            axis = 0;

        return axis;
    }
}