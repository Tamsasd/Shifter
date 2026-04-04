using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMove : MonoBehaviour
{
    protected Rigidbody rb;
    protected float speed = 5f;
    protected float rotationSpeed = 200f;

    protected Transform cameraTransform;

    protected float moveX;
    protected float moveZ;

    protected bool inControl = false;


    [SerializeField] protected bool freezeRotation = true;
    [SerializeField] protected bool canTurn = true;
    [SerializeField] protected bool canMove = true;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = freezeRotation;

        cameraTransform = GameObject.Find("CameraWithPivot").transform;
    }
    protected virtual void Update()
    {
        SetMoveAxis();
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
}
