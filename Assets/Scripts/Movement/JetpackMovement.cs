using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackMovement : AbstractMove
{
    [SerializeField] private float sphereRadius = 0.3f;
    [SerializeField] private float flyForce = 1.0f;

    protected override void Move()
    {

    }

    protected override void Turn()
    {
        throw new System.NotImplementedException();
    }

    protected override void Update()
    {
        if (inControl)
        {
            if (canMove && !IsGrounded())
            {                
                if (!IsGrounded())
                {
                    Move();
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Fly();
                }
            }
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, sphereRadius, -1);
    }

    private void Fly()
    {
        rb.AddForce(transform.up * flyForce);
    }


}
