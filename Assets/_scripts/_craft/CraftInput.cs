using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftInput : MonoBehaviour
{
    Craft _craft;
    Vector2 _scaler;


    private void Awake()
    {
        _craft = GetComponentInChildren<Craft>();
    }

    private void Update()
    {
        Vector3 rotationInput = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), Input.GetAxis("Roll"));
        Vector3 thrustInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Lift"));

        _craft.ReceiveInput(rotationInput, thrustInput);
    }
}