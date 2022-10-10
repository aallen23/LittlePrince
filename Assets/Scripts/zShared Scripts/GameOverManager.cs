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
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        retryButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
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

    void GameOver()
    {
        return;
    }
}
