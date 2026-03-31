using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : Character
{
    private Rigidbody rb;
    public float speed = 1.0f;
    private Transform cameraTransform;

    public override Vector3 GetCameraOffset()
    {
        return cameraOffset;
    }

    public override void ToggleControl(bool value)
    {
        inControl = value;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        cameraTransform = GameObject.Find("CameraWithPivot").transform;
    }

    void Update()
    {
        if (inControl)
        {
            SetMoveAxis();
        }
    }

    void SetMoveAxis()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (inControl)
        {
            Move();
        }
    }
    void Move()
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