using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Image medal;
    public TMP_Text score;
    public TMP_Text highScore;
    public Button okButton;

    public Sprite[] medals;

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
