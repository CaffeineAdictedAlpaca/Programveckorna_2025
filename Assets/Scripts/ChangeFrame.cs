using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFrame : MonoBehaviour
{
    FadeScript fade;
    [SerializeField] private List<GameObject> frame = new List<GameObject>();
    [SerializeField] int changeTo;
    [SerializeField] int thisFrame;

    private void Start()
    {
        fade = GameObject.FindAnyObjectByType<FadeScript>();
    }
    // Function to call when the object is clicked
    public void OnObjectClicked()
    {
        StartCoroutine(Change());
    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();
    }

    public IEnumerator Change()
    {
        fade.StartFade();
        // Wait (adjust duration as needed)
        yield return new WaitForSeconds(0.4f);
        frame[thisFrame-1].SetActive(false);
        frame[changeTo -1].SetActive(true);
        fade.EndFade();
    }
}