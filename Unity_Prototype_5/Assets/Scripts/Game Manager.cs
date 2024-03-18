using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    private int lives;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    private bool paused;
    void Start()
    {
        
       
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            
        }

    }
    public void UpdateScore(int addToScore)
    {
        score += addToScore;
        scoreText.text = "Score : " + score;
    }
    public void UpdateLives(int livesTochange)
    {
        lives += livesTochange;
        livesText.text = "Lives: " + lives;
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive=false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());

        UpdateScore(0);
        UpdateLives(3);
        titleScreen.SetActive(false);
    }

    void ChangePaused()
    {
        if(!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
