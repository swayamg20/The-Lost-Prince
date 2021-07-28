using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentControllers : MonoBehaviour
{
    IInput input;
    AgentMovement movement;
    private void OnEnable()
    {
        input = GetComponent<IInput>();
        movement = GetComponent<AgentMovement>();
        input.OnMovemenetDirectionInput += movement.HandleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
    }

    private void OnDisable()
    {
        input.OnMovemenetDirectionInput -= movement.HandleMovementDirection;
        input.OnMovementInput -= movement.HandleMovement;
    }
}
