using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] string nextScene;
    FadeScript fade;

    private void Start()
    {
        fade = GameObject.FindAnyObjectByType<FadeScript>();
    }
    // Function to call when the object is clicked
    public void OnObjectClicked()
    {
        OpenDoor();
    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();
    }
    public virtual void OpenDoor()
    {
        StartCoroutine(OpenDoorWithDelay());
    }

    private IEnumerator OpenDoorWithDelay()
    {
        // Start the fade effect
        fade.StartFade();

        // Wait for the fade to complete (adjust duration as needed)
        yield return new WaitForSeconds(1.0f);

        // Load the next scene
        SceneManager.LoadScene(nextScene);
    }
}
