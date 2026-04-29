using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    GameManager gameManager;

    private float panSens;
    private float zoomSens;

    private float xRotation = 0f;
    private float yRotation = 0f;

    public Transform cameraTransform;    

    public float minZoomZ = -10f;
    public float maxZoomZ = -1f;
    public float zoomSmoothTime = 0.15f;
    private float targetZoomZ;
    private float zoomVelocity = 0f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        panSens = PlayerPrefs.GetFloat("PanSensitivity", 2000.0f);
        zoomSens = PlayerPrefs.GetFloat("ZoomSensitivity", 3.0f);

        targetZoomZ = cameraTransform.localPosition.z;
    }

    void Update()
    {
        Character controlledCharacter = gameManager.GetControlledObject();
        if (controlledCharacter == null) return;

        controlledCharacter = gameManager.GetControlledObject().GetComponent<Character>();
        transform.position = controlledCharacter.GetCameraPivot().position;

        HandleRotation();
        HandleZoom();
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * panSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * panSens * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    void HandleZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float effectiveSmoothTime = Mathf.Max(0.0001f, zoomSmoothTime);

        if (scrollInput != 0f)
        {

            targetZoomZ += scrollInput * zoomSens;
            targetZoomZ = Mathf.Clamp(targetZoomZ, minZoomZ, maxZoomZ);
        }

        float currentZ = cameraTransform.localPosition.z;

        //float newZ = Mathf.SmoothDamp(currentZ, targetZoomZ, ref zoomVelocity, zoomSmoothTime);
        float newZ = Mathf.SmoothDamp(currentZ, targetZoomZ, ref zoomVelocity, effectiveSmoothTime);

        cameraTransform.localPosition = new Vector3(0, 0, newZ);

        if (!float.IsNaN(newZ))
        {
            cameraTransform.localPosition = new Vector3(0, 0, newZ);
        }
    }
}