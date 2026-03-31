using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mirror : Character
{
    private Rigidbody rb;
    [SerializeField] private float rollSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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

    void FixedUpdate()
    {
        if (inControl)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        rb.AddForce(forward * rollSpeed * moveX);
    }

    public override Vector3 GetCameraOffset()
    {
        return cameraOffset;
    }

    public override void ToggleControl(bool value)
    {
        inControl = value;
    }

    public override bool HasControl()
    {
        return inControl;
    }
}
