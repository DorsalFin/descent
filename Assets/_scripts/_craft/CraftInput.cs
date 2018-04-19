using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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
        Vector3 rotationInput = new Vector3(CrossPlatformInputManager.GetAxis("Mouse X"), CrossPlatformInputManager.GetAxis("Mouse Y"), CrossPlatformInputManager.GetAxis("Roll"));
        Vector3 thrustInput = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), CrossPlatformInputManager.GetAxis("Lift"));

        _craft.ReceiveInput(rotationInput, thrustInput);
    }
}