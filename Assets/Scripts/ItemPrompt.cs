using UnityEngine;
using UnityEngine.UI;

public class ItemPrompt : MonoBehaviour
{
    public GameObject item; // Reference to the item GameObject
    public GameObject promptPanel; // Reference to the prompt panel UI
    public Button yesButton; // Reference to the Yes button
    public Button noButton; // Reference to the No button
    [SerializeField] float attackPercent;
    [SerializeField] float healthPercent;
    [SerializeField] float charismaPercent;
    [SerializeField] int moneyAmount;
    public StatManager statManager;
    


    void Start()
    {
        attackPercent = attackPercent / 10;
        healthPercent = healthPercent / 10;        
        charismaPercent = charismaPercent / 10;

        statManager = GameObject.FindAnyObjectByType<StatManager>();

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
    // Called when the button below the item is pressed
    public void ShowPrompt()
    {
        if (promptPanel != null)
        {
            promptPanel.SetActive(true);
        }
    }

    // Called when Yes is clicked
    public void AcceptItem()
    {
        print("You accepted the item!");
        ClosePrompt();

        if (statManager != null)
        {
            statManager.attack += statManager.attack * attackPercent; // Increase attack by attakPercent;
            statManager.health += statManager.health * healthPercent;
            statManager.charisma += statManager.charisma * charismaPercent;
            statManager.money += moneyAmount;
        }
        else
        {
            Debug.LogWarning("StatManager not found!");
        }

    }

    // Called when No is clicked
    public void DeclineItem()
    {
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
}
