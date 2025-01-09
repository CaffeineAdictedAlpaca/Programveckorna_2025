using UnityEngine;
using UnityEngine.UI;

public class SwordPrompt : MonoBehaviour
{
    public GameObject sword; // Reference to the sword GameObject
    public GameObject promptPanel; // Reference to the prompt panel UI
    public Button yesButton; // Reference to the Yes button
    public Button noButton; // Reference to the No button

    private StatManager statManager;


    void Start()
    {
        statManager = GameObject.FindAnyObjectByType<StatManager>();


        // Ensure the prompt panel is initially inactive
        if (promptPanel != null)
        {
            promptPanel.SetActive(false);
        }

        // Add listeners to Yes and No buttons
        if (yesButton != null)
        {
            yesButton.onClick.AddListener(AcceptSword);
        }

        if (noButton != null)
        {
            noButton.onClick.AddListener(DeclineSword);
        }
    }
    // Function to call when the object is clicked
    public void OnObjectClicked()
    {
        ShowPrompt();

        
    }

    private void OnMouseDown()
    {
        // Detect mouse click on the object's collider
        OnObjectClicked();
    }
    // Called when the button below the sword is pressed
    public void ShowPrompt()
    {
        if (promptPanel != null)
        {
            promptPanel.SetActive(true);
        }
    }

    // Called when Yes is clicked
    void AcceptSword()
    {

        

        Debug.Log("You accepted the sword!");
        ClosePrompt();

        if (statManager != null)
        {
            statManager.attack += statManager.attack * 0.2f; // Increase attack by 20%
        }
        else
        {
            Debug.LogWarning("StatManager not found!");
        }

    }

    // Called when No is clicked
    void DeclineSword()
    {
        Debug.Log("You declined the sword.");

        

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
}
