using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameManager gameManager;

    public float mouseSensitivity = 100f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

        Character controlledCharacter = gameManager.GetControlledObject().GetComponent<Character>();
        Vector3 cameraOffset = controlledCharacter.GetCameraOffset();

        transform.position = controlledCharacter.transform.position + cameraOffset;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}