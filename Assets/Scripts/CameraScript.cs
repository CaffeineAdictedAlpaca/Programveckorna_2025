using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity = 5f; // Adjust how much the camera moves
    public float maxAngle = 10f;   // Maximum angle the camera can rotate

    private Vector2 screenCenter;

    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        // Calculate how far the mouse is from the center (normalized -1 to 1 range)
        float xOffset = Mathf.Clamp((mousePos.x - screenCenter.x) / screenCenter.x, -1f, 1f);
        float yOffset = Mathf.Clamp((mousePos.y - screenCenter.y) / screenCenter.y, -1f, 1f);

        // Calculate target rotation based on mouse offset
        float targetXRotation = -yOffset * maxAngle;
        float targetYRotation = xOffset * maxAngle;

        // Apply rotation smoothly
        Quaternion targetRotation = Quaternion.Euler(targetXRotation, targetYRotation, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * sensitivity);
    }
}
