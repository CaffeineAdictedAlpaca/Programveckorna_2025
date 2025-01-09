using UnityEngine;

public class LimitedFirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 2f;          // Mouse sensitivity
    public float maxVerticalAngle = 45f;   // Maximum up/down angle (degrees)
    public float minHorizontalAngle = -90f; // Minimum left angle (degrees)
    public float maxHorizontalAngle = 90f; // Maximum right angle (degrees)

    private float verticalRotation = 0f;   // Current vertical rotation
    private float horizontalRotation = 0f; // Current horizontal rotation





    public void Start()
    {
        // Initialize the horizontal rotation with the camera's initial Y-rotation
        horizontalRotation = transform.eulerAngles.y;

        


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

        // Adjust horizontal rotation (yaw)
        horizontalRotation += mouseX;
        horizontalRotation = Mathf.Clamp(horizontalRotation, minHorizontalAngle, maxHorizontalAngle);

        // Adjust vertical rotation (pitch)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        // Apply the clamped rotations to the camera
        transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0f);
    }
}
