using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public GameObject blackUIPanel;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        retryButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        blackUIPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (TimeManager.timer <= 0)
        //{
        //  gameOver = true;
        //  GameOver();
        //}
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        retryButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        blackUIPanel.SetActive(true);
        retryButton.onClick.AddListener(Retry);
    }

    public void Retry()
    {
        retryButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        blackUIPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
