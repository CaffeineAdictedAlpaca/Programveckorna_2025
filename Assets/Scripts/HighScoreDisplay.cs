using UnityEngine;
using UnityEngine.UI;


public class HighScoreDisplay : MonoBehaviour
{
    public Text yourScore;
    public Text highScoreText;
    StatManager statManager;


    private void Start()
    {
        statManager = FindObjectOfType<StatManager>();
    }
    void Update()
    {
        if (statManager != null)
        {
            highScoreText.text = "Most Money Collected: " + statManager.GetHighScore();
        }

        yourScore.text = "Your Money Collected: " + statManager.money;



    }
}
