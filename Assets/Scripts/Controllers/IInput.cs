using System;
using UnityEngine;

public interface IInput
{
    Action<Vector3> OnMovemenetDirectionInput { get; set; }
    Action<Vector2> OnMovementInput { get; set; }
}