using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFrame : MonoBehaviour
{
    FadeScript fade;
    [SerializeField] private List<GameObject> frame = new List<GameObject>();
    [SerializeField] int changeTo;
    [SerializeField] int thisFrame;
    [SerializeField] bool dissableCamera;
    [SerializeField] bool disableSword;
    CameraScript cameraScript;

    private void Start()
    {
        //sword = GameObject.FindGameObjectWithTag("Sword").gameObject;
        cameraScript = GameObject.FindAnyObjectByType<CameraScript>().GetComponent<CameraScript>();
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
        yield return new WaitForSeconds(0.4f);
        GameObject cameraObject = cameraScript.gameObject;
        if (disableSword)
        {
            Transform firstChild = cameraObject.transform.GetChild(0);
            firstChild.gameObject.SetActive(false);
            Debug.Log("Activated: " + firstChild.gameObject.name);
        }
        else if (cameraObject.transform.childCount > 0)
        {
            Transform firstChild = cameraObject.transform.GetChild(0);
            firstChild.gameObject.SetActive(true);
            Debug.Log("Activated: " + firstChild.gameObject.name);
        }
        else
        {
            Debug.LogWarning("No child found to activate under the camera.");
        }
        if (dissableCamera)
        {
            cameraScript.enabled = false;
        }
        else
        {
            cameraScript.enabled = true;
        }
        frame[thisFrame-1].SetActive(false);
        frame[changeTo -1].SetActive(true);
        fade.EndFade();
    }
}
