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
    private float acelerationRotateV;
    [SerializeField]
    private float decelerationRotateV;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private Rigidbody rb;

    void Update()
    {
        SpeedUp();
        //Deceleration(rb.velocity.x, true);
        //Deceleration(rb.velocity.y, false);
        //DecelerationRotate(rb.angularVelocity.x, true);
        //Deceleration(rb.angularVelocity.y, false);
        //StabilizeRotate();
    }

    
    void SpeedUp()
    {
        //print("x :  " + speedX + "  y :  " + speedY);
        //print("x :  " + rb.velocity.x + "  y :  " + rb.velocity.y);
        if (Input.GetAxis("Vertical") > 0 && rb.velocity.y < maxSpeed)
        {
            rb.AddForce(new Vector2(0, acelerationV * Time.deltaTime));
            //rb.AddTorque(new Vector2(-acelerationRotateV, 0));
        }
        if (Input.GetAxis("Vertical") < 0 && rb.velocity.y > -maxSpeed)
        {
            rb.AddForce(new Vector2(0, -acelerationV * Time.deltaTime));
            //rb.AddTorque(new Vector2(acelerationRotateV, 0));
        }
        if (Input.GetAxis("Horizontal") > 0 && rb.velocity.x < maxSpeed)
        {
            rb.AddForce(new Vector2(acelerationV * Time.deltaTime, 0));
            //rb.AddTorque(new Vector3(0, 0,-acelerationRotateV));
        }
        if (Input.GetAxis("Horizontal") < 0 && rb.velocity.x > -maxSpeed)
        {
            rb.AddForce(new Vector2(-acelerationV * Time.deltaTime, 0));
            //rb.AddTorque(new Vector2(0, acelerationRotateV));
        }
    }
    void StabilizeRotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0,0,0,0) , Time.deltaTime * decelerationV);
    }
    void Deceleration(float axis, bool x)
    {
        if (axis != 0)
        {
            if (axis > 0)
            {
                if(x)
                    rb.AddForce(new Vector2(decelerationV * Time.deltaTime, 0));
                else
                    rb.AddForce(new Vector2(0, decelerationV * Time.deltaTime));
            }
            if (axis < 0)
            {
                if (x)
                    rb.AddForce(new Vector2(-decelerationV * Time.deltaTime, 0));
                else
                    rb.AddForce(new Vector2(0, -decelerationV * Time.deltaTime));
            }
        }
        if (axis > -0.001f && axis < 0.001f)
            axis = 0;
    }
    void DecelerationRotate(float axis, bool x)
    {
        if (axis != 0)
        {
            if (axis > 0)
            {
                if (x)
                    rb.AddTorque(new Vector2(decelerationRotateV * Time.deltaTime, 0));
                else
                    rb.AddTorque(new Vector2(0, decelerationRotateV * Time.deltaTime));
            }
            if (axis < 0)
            {
                if (x)
                    rb.AddTorque(new Vector2(-decelerationRotateV * Time.deltaTime, 0));
                else
                    rb.AddTorque(new Vector2(0, -decelerationRotateV * Time.deltaTime));
            }
        }
        if (axis > -6f && axis < 6f)
            axis = 0;
    }
}