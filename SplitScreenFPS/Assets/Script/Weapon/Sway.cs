using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    public float intensity = 10;
    public float smooth = 4;

    public VariableJoystick cameraJoy;

    Quaternion originRotation;

    private void Start()
    {
        originRotation = transform.localRotation;
    }
    void Update()
    {
        UpdateSway();
    }
    void UpdateSway()
    {
        float mouseX = cameraJoy.Horizontal;
        float mouseY = cameraJoy.Vertical;

        Quaternion adjX = Quaternion.AngleAxis(-intensity * mouseX, Vector3.up);
        Quaternion adjY = Quaternion.AngleAxis(intensity * mouseY, Vector3.right);
        Quaternion targetRotation = originRotation * adjX * adjY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
    }
}
