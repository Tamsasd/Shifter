using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameManager gameManager;

    private float panSens;
    private float zoomSens;

    private float xRotation = 0f;
    private float yRotation = 0f;

    [Header("References")]
    [Tooltip("Drag the child here by its arms")]
    public Transform cameraTransform; // Gugu aut mondta ez megoldja minden problémám

    public float minZoomZ = -10f;
    public float maxZoomZ = -1f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        panSens = PlayerPrefs.GetFloat("PanSensitivity", 2000.0f);
        zoomSens = PlayerPrefs.GetFloat("ZoomSensitivity", 3.0f);
    }

    void Update()
    {

        Character controlledCharacter = gameManager.GetControlledObject().GetComponent<Character>();

        transform.position = controlledCharacter.GetCameraPivot().position;

        float mouseX = Input.GetAxis("Mouse X") * panSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * panSens * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // Zoom stuff:
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0f)
        {
            float zoomAmount = scrollInput * zoomSens;

            // Move the child camera
            cameraTransform.Translate(0, 0, zoomAmount, Space.Self);

            // Clamp the child's location
            Vector3 clampedPosition = cameraTransform.localPosition;
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZoomZ, maxZoomZ);
            cameraTransform.localPosition = clampedPosition;
        }
    }
}