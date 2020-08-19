using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public VariableJoystick movementJoy;

    public float moveSpeed = 10;
    public bool invertMoveX;
    public bool invertMoveY;

    float horizontalMoveInput;
    float verticalMoveInput;

    Transform myTransform;

    Vector3 movement;

    void Start()
    {
        myTransform = GetComponent<Transform>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if(!invertMoveX)
            horizontalMoveInput = movementJoy.Horizontal;
        else
            horizontalMoveInput = -movementJoy.Horizontal;
        if(!invertMoveY)
            verticalMoveInput = movementJoy.Vertical;
        else
            verticalMoveInput = -movementJoy.Vertical;

        myTransform.Translate(horizontalMoveInput * moveSpeed * Time.deltaTime, 0, verticalMoveInput * moveSpeed * Time.deltaTime, Space.Self);
    }
}
