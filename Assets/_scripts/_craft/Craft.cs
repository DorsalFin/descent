using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    public Camera pilotCamera;
    public float craftRotateSpeed;
    public float craftThrustSpeed;

    public Vector3 Velocity { get { return _rb.velocity; } }
    public Vector3 AngularVelocity { get { return _rb.angularVelocity; } }
    
    Rigidbody _rb;
    Vector3 _rotationInput;
    Vector3 _thrustInput;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void ReceiveInput(Vector3 rotationInput, Vector3 thrustInput)
    {
        _rotationInput = rotationInput;
        _thrustInput = thrustInput;
    }

    private void FixedUpdate()
    {
        _rb.AddRelativeTorque(-_rotationInput.y * craftRotateSpeed, _rotationInput.x * craftRotateSpeed, _rotationInput.z * craftRotateSpeed);
        _rb.AddRelativeForce(_thrustInput.x * craftThrustSpeed, _thrustInput.z * craftThrustSpeed, _thrustInput.y * craftThrustSpeed);
    }
}