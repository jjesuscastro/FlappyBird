using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private BirdController player;
    [SerializeField]
    private PipeSpawner pipeSpawner;
    [SerializeField]
    private AudioController audioController;
    [SerializeField]
    private GameObject gameStartUI;
    [SerializeField]
    private GameOver gameOverUI;
    [SerializeField]
    private TMP_Text scoreText;
    
    private int highScore;
    private int score = 0;

    private void Start()
    {
        this.player.onFlap.AddListener(delegate {
            this.audioController.PlayFlap();
        });
        this.player.onPipePassed.AddListener(AddScore);
        this.player.onPipeHit.AddListener(GameOver);
        this.gameOverUI.okButton.onClick.AddListener(RestartGame);

        this.highScore = PlayerPrefs.GetInt("highScore");
    }

    private void AddScore()
    {
        this.score++;
        this.scoreText.text = this.score.ToString();
        
        this.audioController.PlayPoint();
    }

    public void GameStart() {
        if (!this.gameStartUI.activeInHierarchy)
            return;

        this.gameStartUI.SetActive(false);
        this.player.StartMoving();
        this.pipeSpawner.StartSpawning();
    }

    private void GameOver() {
        if (this.player.IsDead)
            return;
        
        this.player.StopMoving();
        this.pipeSpawner.StopSpawning();

        this.scoreText.gameObject.SetActive(false);
        this.gameOverUI.gameObject.SetActive(true);
        this.highScore = (this.highScore > this.score) ? this.highScore : this.score;
        PlayerPrefs.SetInt("highScore", this.highScore);

        this.gameOverUI.SetScore(this.score, this.highScore);
        
        this.audioController.PlayHit();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
