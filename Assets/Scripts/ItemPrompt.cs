using UnityEngine;
using UnityEngine.UI;

public class ItemPrompt : MonoBehaviour
{
    public GameObject item; // Reference to the item GameObject
    public GameObject promptPanel; // Reference to the prompt panel UI
    public Button yesButton; // Reference to the Yes button
    public Button noButton; // Reference to the No button
    [SerializeField] float addAttackPercent;
    [SerializeField] float addHealthPercent;
    [SerializeField] float addCharismaPercent;
    [SerializeField] float addMaxHealthPercent;
    [SerializeField] int moneyAmount;
    public StatManager statManager;
    public GameObject statDisplay;
    public GameObject gameUI;



    void Start()
    {
        addMaxHealthPercent = addMaxHealthPercent / 100;
        addAttackPercent = addAttackPercent / 100;
        addHealthPercent = addHealthPercent / 100;        
        addCharismaPercent = addCharismaPercent / 100;



        gameUI = GameObject.FindAnyObjectByType<UI>().gameObject;
        statDisplay = gameUI.transform.GetChild(1).gameObject;
        statManager = GameObject.FindAnyObjectByType<StatManager>().GetComponent<StatManager>();

        // Ensure the prompt panel is initially inactive
        if (promptPanel != null)
        {
            promptPanel.SetActive(false);
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

        statDisplay.SetActive(false);

        if (promptPanel != null)
        {
            promptPanel.SetActive(true);
        }
    }

    // Called when Yes is clicked
    public void AcceptItem()
    {



        statDisplay.SetActive(true);

        print("You accepted the item!");
        ClosePrompt();

        if (statManager != null)
        {
            statManager.attack += statManager.attack * addAttackPercent; // Increase attack by addAttakPercent;
            statManager.health += statManager.health * addHealthPercent;
            statManager.charisma += statManager.charisma * addCharismaPercent;
            statManager.money += moneyAmount;
            statManager.maxHealth += statManager.maxHealth * addMaxHealthPercent;
        }
        else
        {
            Debug.LogWarning("StatManager not found!");
        }
        Destroy(gameObject);

    }

    // Called when No is clicked
    public void DeclineItem()
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
}
