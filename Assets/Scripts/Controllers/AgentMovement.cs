using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    CharacterController controller;
    public float rotationSpeed;
    public float movementSpeed;
    public float gravity = 20f;

    Vector3 movementVector = Vector3.zero;

    float desiredRotationAngle = 0;
    private void Start()
    {
        GetComponent<CharacterController>();
    }

    public void HandleMovement(Vector2 input)
    {
        if(controller.isGrounded)
        {
            if(input.y>0)
            {
                movementVector = transform.forward * movementSpeed;
            }
            else
            {
                movementVector = Vector3.zero;
            }
        }
    }

    public void HandleMovementDirection(Vector3 direction)
    {

    }
    private void Update()
    {
        movementVector.y -= gravity;
        controller.Move(movementVector * Time.deltaTime);

    }
}
