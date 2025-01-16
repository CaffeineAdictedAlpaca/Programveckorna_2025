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
    [SerializeField] bool disableUI;
    CameraScript cameraScript;
    GameObject UI;
    GameObject cameraObj;

    private void Start()
    {
        //sword = GameObject.FindGameObjectWithTag("Sword").gameObject;
        cameraScript = GameObject.FindAnyObjectByType<CameraScript>().GetComponent<CameraScript>();
        cameraObj = GameObject.FindAnyObjectByType<CameraScript>().gameObject;
        fade = GameObject.FindAnyObjectByType<FadeScript>();
        UI = GameObject.FindAnyObjectByType<UI>().gameObject;
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
        if (disableUI)
        {
            Transform child = UI.transform.GetChild(1);
            child.gameObject.SetActive(false);
            Debug.Log("Activated: " + child.gameObject.name);
        }
        else if(UI.transform.childCount > 0)
        {
            Transform child = UI.transform.GetChild(1);
            child.gameObject.SetActive(true);
            Debug.Log("Activated: " + child.gameObject.name);
        }
        else
        {
            Debug.LogWarning("No child found to activate under the GameUI.");
        }
        if (dissableCamera)
        {
            cameraScript.enabled = false;
        }
        else
        {
            cameraScript.enabled = true;
        }
        cameraObj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        frame[thisFrame-1].SetActive(false);
        frame[changeTo -1].SetActive(true);
        fade.EndFade();
    }
}
