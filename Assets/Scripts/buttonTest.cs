using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTest : MonoBehaviour
{
    [SerializeField]
    GameObject flaska;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            flaska.SetActive(false);
        }
    }
    // Function to call when the object is clicked
    public void OnObjectClicked()
    {
        click();
    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();
    }
    public void click()
    {
        flaska.SetActive(true);
    }
}
