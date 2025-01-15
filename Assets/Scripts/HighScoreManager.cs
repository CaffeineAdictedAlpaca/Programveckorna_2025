using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0); // Default is 0
    }

    public static void SaveHighScore(int newScore)
    {
        if (newScore > GetHighScore())
        {
            PlayerPrefs.SetInt(HighScoreKey, newScore);
            PlayerPrefs.Save();
        }
    }
}
