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
        Vector3 targetVelocity = GetMoveDirection() * speed;

        targetVelocity.y = rb.velocity.y;
        rb.velocity = targetVelocity;
    }

    protected override void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
    }
}