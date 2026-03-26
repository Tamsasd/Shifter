using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float Speed = 5f;
    public float jumpForce = 5f;

    public float mouseSensitivity = 100f;
    public Transform cameraPivot;

    private float xRotation = 0f;
    private float moveX;
    private float moveZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // csak akkor ugrik ha a földön van -> raycast lefele hogy ütközik-e valamivel
            // 1.1 mert 2 magas a karakter + egy pici
            if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = (transform.right * moveX + transform.forward * moveZ).normalized;

        Vector3 targetVelocity = moveDirection * Speed;

        targetVelocity.y = rb.velocity.y;

        rb.velocity = targetVelocity;
    }
}