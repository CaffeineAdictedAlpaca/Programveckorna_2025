using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float attack;
    public float agility;
    public float charisma;
    public int money;

    private int highScore;

    void Start()
    {
        // Keep StatManager when changing scene
        DontDestroyOnLoad(gameObject);

        // Load the saved high score (if it exists)
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Update()
    {
        // Ensure health doesn't exceed maxHealth
        if (health > maxHealth)
        {
            health = maxHealth;
        }



        
        // Update the high score if the current money exceeds it
        if (money > highScore)
        {
            highScore = money;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }
}
