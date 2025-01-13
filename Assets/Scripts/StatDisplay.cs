using TMPro; // For TextMeshPro
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI charismaText;
    public TextMeshProUGUI moneyText;

    private StatManager statManager;

    void Start()
    {
        // Find the StatManager instance
        statManager = FindObjectOfType<StatManager>();
    }

    void Update()
    {
        if (statManager != null)
        {
            // Update the UI with the stats
            
            attackText.text = "Attack: " + statManager.attack.ToString("F0");
            charismaText.text = "Charisma: " + statManager.charisma.ToString("F0");
            moneyText.text = "Money: " + statManager.money.ToString();
            
        }
    }
}
