using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractMove : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float rotationSpeed = 200f;

    [SerializeField] private float sphereRadius = 0.3f;
    [SerializeField] private LayerMask playerMask;

    protected Transform cameraTransform;

    protected float moveX;
    protected float moveZ;

    protected bool inControl = false;


    [SerializeField] protected bool freezeRotation = true;
    [SerializeField] protected bool canTurn = true;
    [SerializeField] protected bool canMove = true;
    [SerializeField] protected bool canJump = false;
    [SerializeField] protected float jumpForce = 50.0f;

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

    void SetMoveAxis()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
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
        return Physics.CheckSphere(transform.position, sphereRadius, ~playerMask);
    }
}
