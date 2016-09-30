using UnityEngine;
using System.Collections;
using System;

public class PaperMove : MonoBehaviour
{
    [SerializeField]
    private float acelerationV;
    [SerializeField]
    private float decelerationV;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private Rigidbody rb;
    private float speedX;
    private float speedY;

    void Update()
    {
        SpeedUp();
        rb.AddForce(new Vector2(speedX, speedY));
        speedX = deceleration(speedX,true); speedY = deceleration(speedY,false);
    }

    void SpeedUp()
    {
        //print("x :  " + speedX + "  y :  " + speedY);
        //print("x :  " + rb.velocity.x + "  y :  " + rb.velocity.y);
        if (Input.GetAxis("Vertical") > 0 && rb.velocity.y < maxSpeed)
        {
            rb.AddForce(new Vector2(0, acelerationV * Time.deltaTime));

        }
        if (Input.GetAxis("Vertical") < 0 && rb.velocity.y > -maxSpeed)
        {
            rb.AddForce(new Vector2(0, -acelerationV * Time.deltaTime));
        }
        if (Input.GetAxis("Horizontal") > 0 && rb.velocity.x < maxSpeed)
        {
            rb.AddForce(new Vector2(acelerationV * Time.deltaTime, 0));
        }
        if (Input.GetAxis("Horizontal") < 0 && rb.velocity.x > -maxSpeed)
        {
            rb.AddForce(new Vector2(-acelerationV * Time.deltaTime, 0));
        }
    }
    float deceleration(float axis, bool x)
    {
        if (axis != 0)
        {
            if (axis > 0)
            {
                axis -= decelerationV * Time.deltaTime;
                if(x)
                    rb.AddForce(new Vector2(decelerationV * Time.deltaTime, 0));
                else
                    rb.AddForce(new Vector2(0, decelerationV * Time.deltaTime));
            }
            if (axis < 0)
            {
                axis += decelerationV * Time.deltaTime;
                if (x)
                    rb.AddForce(new Vector2(-decelerationV * Time.deltaTime, 0));
                else
                    rb.AddForce(new Vector2(0, -decelerationV * Time.deltaTime));
            }
        }
        if (axis > -0.001f && axis < 0.001f)
            axis = 0;
        return axis;
    }
}