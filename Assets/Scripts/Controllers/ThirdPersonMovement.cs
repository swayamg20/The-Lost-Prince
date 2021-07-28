using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;

    public Animator animator;
    public Transform cam;

    public float speed = 6f;
    float smooth = 10f;

    public float turnTime = 0.1f;

    float turnVelocity = 0f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        animator.SetBool("IsWalking", false);
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y ;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity,smooth);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            animator.SetBool("IsWalking", true);
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            if ((controller.collisionFlags & CollisionFlags.Sides) != 0)
            {
                print("Touching sides!");
            }

            if (controller.collisionFlags == CollisionFlags.Sides)
            {
                print("Only touching sides, nothing else!");
            }

            if ((controller.collisionFlags & CollisionFlags.Above) != 0)
            {
                print("Touching Ceiling!");
            }

            if (controller.collisionFlags == CollisionFlags.Above)
            {
                print("Only touching Ceiling, nothing else!");
            }

            if ((controller.collisionFlags & CollisionFlags.Below) != 0)
            {
                print("Touching ground!");
            }

            if (controller.collisionFlags == CollisionFlags.Below)
            {
                print("Only touching ground, nothing else!");
            }
        }

    }
}
