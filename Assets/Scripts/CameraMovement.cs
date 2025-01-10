using UnityEngine;

public class CameraEdgeLimit : MonoBehaviour
{
    public float sensitivity = 2f; // Mouse sensitivity
    public float maxVerticalAngle; // Maximum up/down angle (degrees)
    public float maxHorizontalAngle; // Maximum left/right angle (degrees)

    // The distance from the camera to the scene’s boundaries
    public float boundaryPadding = 2f;

    private float verticalRotation = 0f;   // Current vertical rotation
    private float horizontalRotation = 0f; // Current horizontal rotation

    void Update()
    {
        HandleMouseLook();
        RestrictCameraPosition();
    }

    private void HandleMouseLook()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Adjust horizontal rotation (yaw)
        horizontalRotation += mouseX;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -maxHorizontalAngle, maxHorizontalAngle);

        // Adjust vertical rotation (pitch)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        // Apply the clamped rotations to the camera
        transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0f);
    }

    private void RestrictCameraPosition()
    {
        // Calculate the current position of the camera in screen space
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Get the current screen width and height
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // If the camera is near the edges of the screen, restrict its movement
        if (screenPos.x <= boundaryPadding || screenPos.x >= screenWidth - boundaryPadding)
        {
            horizontalRotation = Mathf.Clamp(horizontalRotation, -maxHorizontalAngle, maxHorizontalAngle);
        }

        if (screenPos.y <= boundaryPadding || screenPos.y >= screenHeight - boundaryPadding)
        {
            verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);
        }

        // Apply restricted positions if necessary (optional: use screen coordinates to control movement)
    }
}
