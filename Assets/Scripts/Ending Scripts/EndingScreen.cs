using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour
{
    private Button retryButton;
    private Button quitButton;

    public TextMeshProUGUI totalFlowers;
    public TextMeshProUGUI bestFlowers;
    public TextMeshProUGUI totalHealthT;
    public TextMeshProUGUI bestHealthT;
    public TextMeshProUGUI totalTrust;
    public TextMeshProUGUI bestTrust;
    public TextMeshProUGUI totalHealthF;
    public TextMeshProUGUI bestHealthF;

    // Start is called before the first frame update
    void Start()
    {
        retryButton = GameObject.Find("RetryButton").GetComponent<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();

        retryButton.onClick.AddListener(Retry);
        quitButton.onClick.AddListener(QuitGame);

        totalFlowers.text = "Flowers: " + PlayerPrefs.GetInt("FlowerCurrent");
        bestFlowers.text = "Best: " + PlayerPrefs.GetInt("FlowerHighScore");

        totalHealthT.text = "Health: " + PlayerPrefs.GetInt("Lvl2Health");
        bestHealthT.text = "Best: " + PlayerPrefs.GetInt("Lvl2HighScore");

        totalHealthF.text = "Health: " + PlayerPrefs.GetInt("Lvl5Health");
        bestHealthF.text = "Best: " + PlayerPrefs.GetInt("Lvl5HighScore");

        //Add rest here
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Retry()
    {
        SceneManager.LoadScene("Level1");
    }

    void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
