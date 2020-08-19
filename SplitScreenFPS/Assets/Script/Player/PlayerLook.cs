using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public VariableJoystick cameraJoy;

    public Transform cameraParent;
    
    public float sensivity = 0.5f;
    public bool invertLookX;
    public bool invertLookY;

    public float lookDownLimit = -90;
    public float lookUpLimit = 90;

    float horizontalLookInput;
    float verticalLookInput;

    Transform myTransform;
    Vector3 currentEuler;
    Vector3 currentCameraEuler;

    private void OnEnable()
    {
        myTransform = GetComponent<Transform>();
    }
    void Update()
    {
        Look();
    }
    float desiredY;
    float rotAmountX;
    float rotAmountY;
    void Look()
    {
        horizontalLookInput = cameraJoy.Horizontal;
        verticalLookInput = cameraJoy.Vertical;

        rotAmountX = horizontalLookInput * sensivity * Time.deltaTime;
        rotAmountY = verticalLookInput * sensivity * Time.deltaTime;

        currentEuler = myTransform.rotation.eulerAngles;
        currentCameraEuler = cameraParent.localRotation.eulerAngles;

        if (!invertLookY)
            desiredY -= rotAmountY;
        else
            desiredY += rotAmountY;

        if (desiredY > lookUpLimit)
            desiredY = lookUpLimit;
        else if (desiredY < lookDownLimit)
            desiredY = lookDownLimit;
        currentCameraEuler.x = desiredY;

        if(!invertLookX)
            currentEuler.y += rotAmountX;
        else
            currentEuler.y -= rotAmountX;

        myTransform.rotation = Quaternion.Euler(currentEuler);
        cameraParent.localRotation = Quaternion.Euler(currentCameraEuler);
    }
}
