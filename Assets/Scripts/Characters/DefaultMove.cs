using UnityEngine;

public class DefaultMove : MonoBehaviour
{
    private Rigidbody rb;

    public float Speed = 5f;
    public float rotationSpeed = 100f;

    public Transform cameraTransform;

    private float moveX;
    private float moveZ;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        cameraTransform = GameObject.Find("CameraWithPivot").transform;
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime);
        }

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        moveDirection = (forward * moveZ + right * moveX).normalized;
        Vector3 targetVelocity = moveDirection * Speed;

        targetVelocity.y = rb.velocity.y;
        rb.velocity = targetVelocity;
    }

    public Vector3 GetMoveDirection()
    {
        return moveDirection;
    }
}