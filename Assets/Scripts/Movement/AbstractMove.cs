using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class AbstractMove : MonoBehaviour
{
    protected Rigidbody rb;
    protected float moveX;
    protected float moveZ;
    protected bool inControl = false;

    [Header("Moving")]
    [SerializeField] public bool canMove = true;
    [SerializeField] protected float speed = 5f;

    [Header("Turning/Rotating")]
    [SerializeField] public bool canTurn = true;
    [SerializeField] protected float rotationSpeed = 200f;
    [SerializeField] protected bool freezeRotation = true;

    [Header("Jumping")]
    [SerializeField] public bool canJump = false;
    [SerializeField] protected float jumpForce = 50.0f;
    [SerializeField] private float groundCheckSphereRadius = 0.3f;
    [SerializeField] private Vector3 groundCheckOffset = new Vector3(0, 0, 0);
    [SerializeField] private LayerMask notGroundMask;

    public string extraHUDText = "";

    protected Transform cameraTransform;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = freezeRotation;

        cameraTransform = GameObject.Find("CameraWithPivot").transform;
    }
    protected virtual void Update()
    {
        SetMoveAxis();
        if (Input.GetKeyDown(KeyCode.Space) && inControl && canJump && IsGrounded())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (inControl)
        {
            if (canMove)
            {
                Move();
            }
            if (canTurn)
            {
                Turn();
            }
        }
    }
    void SetMoveAxis()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }

    protected abstract void Turn();
    protected abstract void Move();
    protected abstract void Jump();

    public Vector3 GetMoveDirection()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        return (forward * moveZ + right * moveX).normalized;
    }

    public void ToggleControl(bool value)
    {
        inControl = value;
    }

    protected bool IsGrounded()
    {
        Vector3 spherePosition = transform.position + groundCheckOffset;
        return Physics.CheckSphere(spherePosition, groundCheckSphereRadius, ~notGroundMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 spherePosition = transform.position + groundCheckOffset;
        Gizmos.DrawWireSphere(spherePosition, groundCheckSphereRadius);
    }
}
