using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour
{
    [SerializeField] Timer timer;
    public TextMeshProUGUI trustText;
    private float princeTrust = 75.0f;

    // Start is called before the first frame update
    void Start()
    {
        trustText.text = "Trust: " + princeTrust;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timer)
        {

        }

        if (timer.timeLeft <= 0 && princeTrust >= 75)
        {
            GameWon();
        }
        else if (timer.timeLeft <= 0 && princeTrust < 75)
        {
            GameOver();
        }
    }

    void GameOver()
    {

    }

    void GameWon()
    {
        SceneManager.LoadScene("Level5");
    }
}
