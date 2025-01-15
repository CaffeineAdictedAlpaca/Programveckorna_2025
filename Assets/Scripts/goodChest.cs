using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goodChest : MonoBehaviour
{

    public GameObject item; // Reference to the item GameObject
    public GameObject promptPanel; // Reference to the prompt panel UI
    public GameObject statDisplay;
    public Button yesButton; // Reference to the Yes button
    public Button noButton; // Reference to the No button

    public GameObject chestloot;

    [SerializeField] ChangeChest changeFrame;

    // Start is called before the first frame update
    void Start()
    {

        // Ensure the prompt panel is initially inactive
        if (promptPanel != null)
        {
            promptPanel.SetActive(false);
        }

        // Add listeners to Yes and No buttons
        if (yesButton != null)
        {
            yesButton.onClick.AddListener(AcceptItem);
        }

        if (noButton != null)
        {
            noButton.onClick.AddListener(DeclineItem);
        }
    }
    public void OnObjectClicked()
    {
        ShowPrompt();

    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();


        
    }
    // Called when the button below the item is pressed
    public void ShowPrompt()
    {

        statDisplay.SetActive(false);
        if (promptPanel != null)
        {
            promptPanel.SetActive(true);
        }
    }

    void AcceptItem()
    {

        StartCoroutine(changeFrame.Change());

        statDisplay.SetActive(true);

        chestloot.SetActive(true);
        Debug.Log("You accepted the item!");
        ClosePrompt();




    }

    void DeclineItem()
    {

        statDisplay.SetActive(true);
        Debug.Log("You declined the item.");



        ClosePrompt();


    }

    // Hides the prompt panel
    void ClosePrompt()
    {
        if (promptPanel != null)
        {
            promptPanel.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
