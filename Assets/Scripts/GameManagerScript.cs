using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    private int score = 0;
    public GameObject scoreObject;
    public Text scoreText;
    public GameObject deathWindow;
    public PlayerScript playersc;
    public bool gameIsEnabled = true;
    public GameObject heartOne;
    public GameObject heartTwo;
    public GameObject heartThree;

    public Text bestScoreText;
    
    void Start() {
        ScoreSpawn();

        
    }

    public void AddScore() {
        score++;
        scoreText.text = score.ToString();
        Debug.Log(score);
    }

    public void ScoreSpawn() {
        float xRandomValue = Random.Range(-8.32f , 8.32f);
        float yRandomValue = Random.Range(-4.44f, 3.75f);

        Instantiate(scoreObject, new Vector3(xRandomValue, yRandomValue, 0f), Quaternion.identity);
    }


    public void HitPlayer() {
        playersc.playerHealth--;
        HeartController(playersc.playerHealth);
        if (playersc.playerHealth == 0) {
            DeathScene();
        }
    }

    void DeathScene() {
        if (score > PlayerPrefs.GetInt("BestScore")) {
            PlayerPrefs.SetInt("BestScore", score);
        }
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        deathWindow.SetActive(true);
        gameIsEnabled = false;
    }

    public void RestartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HeartController(int health) {
        switch (health) {
            case 0:
                heartOne.SetActive(false);
                heartTwo.SetActive(false);
                heartThree.SetActive(false);
                break;
            case 1:
                heartOne.SetActive(true);
                heartTwo.SetActive(false);
                heartThree.SetActive(false);
                break;
            case 2:
                heartOne.SetActive(true);
                heartTwo.SetActive(true);
                heartThree.SetActive(false);
                break;
            case 3:
                heartOne.SetActive(true);
                heartTwo.SetActive(true);
                heartThree.SetActive(true);
                break;
        }
    }
}
