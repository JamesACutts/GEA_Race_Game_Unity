using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WheelController : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider WheelCollider;
        public Axel axel;

    }

    public float maxAcceleration = 80.0f;
    public float breakAcceleration = 100.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
    }

    void Update()
    {
        GetInputs();
    }

    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }
    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.WheelCollider.motorTorque = moveInput * 500 * maxAcceleration * Time.deltaTime;

        }
    }

    void Steer()
    {
        foreach(var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.WheelCollider.steerAngle = Mathf.Lerp(wheel.WheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach(var wheel in wheels)
            {
                wheel.WheelCollider.brakeTorque = 300 * breakAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach(var wheel in wheels)
            {
                wheel.WheelCollider.brakeTorque = 0;
            }
        }
    }
}

