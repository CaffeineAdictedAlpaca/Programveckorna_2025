using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    FadeScript fade;
    RoomTracker roomTracker;

    [SerializeField] AudioSource sound;

    private void Start()
    {
        fade = GameObject.FindAnyObjectByType<FadeScript>();
        roomTracker = GameObject.FindAnyObjectByType<RoomTracker>();
    }
    // Function to call when the object is clicked
    public void OnObjectClicked()
    {
        OpenDoor();
        sound.Play();
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
        StartCoroutine(fade.FadeOut());
        yield return StartCoroutine(fade.FadeOut());
        yield return new WaitForSeconds(0.1f);

        // Load the next scene
        roomTracker.LoadNextScene();
    }
}
