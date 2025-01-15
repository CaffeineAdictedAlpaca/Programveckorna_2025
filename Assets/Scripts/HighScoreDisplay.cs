using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public StatManager statManager;

    void Update()
    {
        if (statManager != null)
        {
            highScoreText.text = "High Score: " + statManager.GetHighScore();
        }
    }
}
