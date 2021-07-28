using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovements2 : MonoBehaviour, IInput
{
    // Start is called before the first frame update
    public Action<Vector2> OnMovementInput { get; set; }
    public Action<Vector3> OnMovemenetDirectionInput { get; set; }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        GetMovementInput();
        GetMovementDirection();

    }

    private void GetMovementDirection()
    {
        var cameraForwardDirection = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, cameraForwardDirection * 10, Color.red);
        var directionToMoveIn = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
        Debug.DrawRay(Camera.main.transform.position, directionToMoveIn * 10, Color.blue);
        OnMovemenetDirectionInput?.Invoke(directionToMoveIn);
    }

    private void GetMovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMovementInput?.Invoke(input);


    }
}
