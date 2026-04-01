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
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * moveZ + right * moveX).normalized;

        Vector3 targetVelocity = moveDirection * speed;

        Vector3 velocityChange = targetVelocity - rb.velocity;

        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}