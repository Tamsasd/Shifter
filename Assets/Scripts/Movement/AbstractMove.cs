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

    protected Vector3 moveDirection = Vector3.zero;

    protected bool inControl = false;


    [SerializeField] protected bool freezeRotation = true;
    [SerializeField] protected bool canTurn = true;
    [SerializeField] protected bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = freezeRotation;

        cameraTransform = GameObject.Find("CameraWithPivot").transform;
    }
    private void Update()
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
        return moveDirection;
    }

    public void ToggleControl(bool value)
    {
        inControl = value;
    }
}
