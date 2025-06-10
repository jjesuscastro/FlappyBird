using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Image medal;
    [SerializeField]
    private TMP_Text score;
    [SerializeField]
    private TMP_Text highScore;
    [SerializeField]
    private Button okButton;

    [SerializeField]
    private Sprite[] medals;
    
    public Button OkButton { get { return this.okButton; } }

    public void SetScore(int scoreValue, int highScoreValue)
    {
        this.score.text = scoreValue.ToString();
        this.highScore.text = highScoreValue.ToString();

        SetMedal(scoreValue);
    }

    private void SetMedal(int scoreValue)
    {
        if (scoreValue >= 30)
        {
            Color color = this.medal.color;
            color.a = 1;
            this.medal.color = color;

            this.medal.sprite = this.medals[2];
        }
        else if (scoreValue >= 20)
        {
            Color color = this.medal.color;
            color.a = 1;
            this.medal.color = color;

            this.medal.sprite = this.medals[1];
        }
        else if (scoreValue >= 10)
        {
            Color color = this.medal.color;
            color.a = 1;
            this.medal.color = color;

            this.medal.sprite = this.medals[0];
        }
        else
        {
            Color color = this.medal.color;
            color.a = 0;
            this.medal.color = color;

            this.medal.sprite = null;
        }
    }
}
