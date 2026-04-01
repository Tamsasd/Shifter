using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultMove : AbstractMove
{

    protected override void Turn()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    protected override void Move()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        moveDirection = (forward * moveZ + right * moveX).normalized;
        Vector3 targetVelocity = moveDirection * speed;

        targetVelocity.y = rb.velocity.y;
        rb.velocity = targetVelocity;
    }
}