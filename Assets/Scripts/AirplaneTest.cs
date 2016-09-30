using UnityEngine;
using System.Collections;

public class AirplaneTest : MonoBehaviour {
    [SerializeField]
    private float currentV;
    [SerializeField]
    private float acelerationV;
    [SerializeField]
    private float decelerationV;
    [SerializeField]
    private float maxV;


    [SerializeField]
    private float maxRotationV;
    [SerializeField]
    private float acelerationRotationV;
    [SerializeField]
    private float decelerationRotationV;
    private float rotationX_V;
    private float rotationZ_V;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
            SpeedUp();
        FlyRotate();
        Move();
    }

    void SpeedUp()
    {
        if (currentV < maxV)
            currentV += acelerationV * Time.deltaTime;
        if (currentV > maxV)
            currentV = maxV;
    }
    void FlyRotate()
    {
        if (currentV > maxV / 2)
        {
            //if (rotationX_V < maxRotationV)
            rotationX_V = Input.GetAxis("Mouse Y") * acelerationRotationV;
            //if (rotationZ_V < maxRotationV)
            rotationZ_V = Input.GetAxis("Mouse X") * acelerationRotationV;
        }
        decelerationRotation(rotationX_V);
        decelerationRotation(rotationZ_V);
    }
    void decelerationRotation(float axis)
    {
        if (axis != 0)
        {
            if (axis > 0)
                axis -= decelerationRotationV * Time.deltaTime;
            if (axis < 0)
                axis += decelerationRotationV * Time.deltaTime;
        }
        if (axis > -0.05f && axis < 0.05f)
            axis = 0;
    }

    void Move()
    {
        if (currentV > 0)
            currentV -= decelerationV * Time.deltaTime;
        if (currentV < 0)
            currentV = 0;
        transform.Translate(0, 0, currentV);
        transform.Rotate(rotationX_V, 0, rotationZ_V);
    }

}
