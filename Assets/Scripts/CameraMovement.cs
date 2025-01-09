using UnityEngine;

public class LimitedFirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 2f; // Mouse sensitivity
    public float maxVerticalAngle = 45f; // Maximum up/down angle (degrees)

    private float verticalRotation = 0f; // Current vertical rotation


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Adjust vertical rotation
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        // Apply vertical rotation (pitch)
        Vector3 localEulerAngles = transform.localEulerAngles;
        localEulerAngles.x = verticalRotation;
        transform.localEulerAngles = new Vector3(verticalRotation, localEulerAngles.y, localEulerAngles.z);
    }
}
