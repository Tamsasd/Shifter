using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameManager gameManager;

    private float panSens;
    private float zoomSens;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        panSens = PlayerPrefs.GetFloat("PanSensitivity", 100.0f);
        zoomSens = PlayerPrefs.GetFloat("ZoomSensitivity", 100.0f);
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
    }
}