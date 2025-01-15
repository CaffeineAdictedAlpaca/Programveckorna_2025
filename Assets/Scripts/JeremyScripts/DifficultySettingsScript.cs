using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySettingsScript : MonoBehaviour
{
    public enum Difficulty { Easy, Normal, Hard }
    public Difficulty selectedDifficulty;

    public Button applyButton;
    public TMP_Dropdown difficultyDropdown;
    private StatManager statManager;

    private void Start()
    {
        
        statManager = FindObjectOfType<StatManager>();

        
        if (difficultyDropdown.options.Count == 0)
        {
            difficultyDropdown.ClearOptions();
            difficultyDropdown.AddOptions(new List<string> { "Easy", "Normal", "Hard" });
        }

        
        difficultyDropdown.value = 1;
        selectedDifficulty = Difficulty.Normal;

        applyButton.onClick.AddListener(ApplyDifficultySettings);
    }

    public void ApplyDifficultySettings()
    {
        selectedDifficulty = (Difficulty)difficultyDropdown.value;

        if (statManager != null)
        {
            switch (selectedDifficulty)
            {
                case Difficulty.Easy:
                    statManager.maxHealth = 200;
                    statManager.health = 200;
                    statManager.attack = 100;
                    statManager.agility = 300;
                    statManager.charisma = 200;
                    statManager.money = 0;
                    break;

                case Difficulty.Normal:
                    statManager.maxHealth = 100;
                    statManager.health = 100;
                    statManager.attack = 100;
                    statManager.agility = 100;
                    statManager.charisma = 100;
                    statManager.money = 0;
                    break;

                case Difficulty.Hard:
                    statManager.maxHealth = 75;
                    statManager.health = 75;
                    statManager.attack = 75;
                    statManager.agility = 50;
                    statManager.charisma = 75;
                    statManager.money = 0;
                    break;
            }

            Debug.Log($"Difficulty set to {selectedDifficulty}. Stats updated.");
        }
        else
        {
            Debug.LogWarning("StatManager not found in the scene!");
        }
    }
}
