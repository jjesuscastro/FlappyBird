using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public BirdController player;
    public PipeSpawner pipeSpawner;
    public GameObject gameStartUI;
    public GameOver gameOverUI;
    public TMP_Text scoreText;
    int highScore;
    int score = 0;

    void Start()
    {
        player.onPipePassed.AddListener(AddScore);
        player.onPipeHit.AddListener(GameOver);
        gameOverUI.okButton.onClick.AddListener(RestartGame);

        highScore = PlayerPrefs.GetInt("highScore");
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && gameStartUI.activeInHierarchy)
            GameStart();
#endif

        if (Input.touchCount > 0 && gameStartUI.activeInHierarchy)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                GameStart();
            }
        }
    }

    void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void GameStart()
    {
        gameStartUI.SetActive(false);
        player.StartMoving();
        pipeSpawner.StartSpawning();
    }

    void GameOver()
    {
        player.StopMoving();
        pipeSpawner.StopSpawning();

        scoreText.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
        highScore = (highScore > score) ? highScore : score;
        PlayerPrefs.SetInt("highScore", highScore);

        gameOverUI.SetScore(score, highScore);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
