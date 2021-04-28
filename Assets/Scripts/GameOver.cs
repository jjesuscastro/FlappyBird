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
        score.text = scoreValue.ToString();
        highScore.text = highScoreValue.ToString();

        SetMedal(scoreValue);
    }

    void SetMedal(int scoreValue)
    {
        if (scoreValue >= 30)
        {
            Color color = medal.color;
            color.a = 1;
            medal.color = color;

            medal.sprite = medals[2];
        }
        else if (scoreValue >= 20)
        {
            Color color = medal.color;
            color.a = 1;
            medal.color = color;

            medal.sprite = medals[1];
        }
        else if (scoreValue >= 10)
        {
            Color color = medal.color;
            color.a = 1;
            medal.color = color;

            medal.sprite = medals[0];
        }
        else
        {
            Color color = medal.color;
            color.a = 0;
            medal.color = color;

            medal.sprite = null;
        }
    }
}
