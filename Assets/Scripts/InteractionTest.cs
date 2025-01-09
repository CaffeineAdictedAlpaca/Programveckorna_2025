using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : MonoBehaviour
{
    // Function to call when the object is clicked
    public void OnObjectClicked()
    {
        print("Open door");
        // Add your desired functionality here
    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();
    }
}
