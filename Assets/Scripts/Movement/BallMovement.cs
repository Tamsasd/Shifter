using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallMovement : AbstractMove
{
    private void FixedUpdate()
    {
        if (inControl)
        {
            Move();
        }
    }
    protected override void Turn()
    {
        return;
    }

    protected override void Move()
    {
        Vector3 targetVelocity = GetMoveDirection() * speed;

        Vector3 velocityChange = targetVelocity - rb.velocity;

        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}