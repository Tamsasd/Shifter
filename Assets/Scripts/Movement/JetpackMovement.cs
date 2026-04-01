using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackMovement : AbstractMove
{
    [SerializeField] private float sphereRadius = 0.3f;
    [SerializeField] private float flyForce = 50.0f;
    [SerializeField] private float pivotSpeed = 10.0f;
    [SerializeField] private float tiltAngle = 30.0f;
    [SerializeField] private LayerMask playerMask;
    private bool isPressingFly = false;

    protected override void Move()
    {
        if (isPressingFly)
        {
            Fly();
        }

        if (IsGrounded()) return;

        Vector3 moveDirection = GetMoveDirection();
        Quaternion targetRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        if (moveDirection.magnitude > 0.01f)
        {
            Quaternion lookRot = Quaternion.LookRotation(moveDirection);

            Quaternion tiltRot = Quaternion.Euler(tiltAngle, 0, 0);

            targetRotation = lookRot * tiltRot;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * pivotSpeed);
    }


    protected override void Update()
    {
        base.Update();

        if (inControl && canMove)
        {
            isPressingFly = Input.GetKey(KeyCode.Space);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, sphereRadius, ~playerMask);
    }

    private void Fly()
    {
        rb.AddForce(transform.up * flyForce);
    }

    protected override void Turn()
    {
        throw new System.NotImplementedException();
    }
}