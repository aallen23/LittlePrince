using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeIsUp : MonoBehaviour
{
    private Timer Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void TimeUp()
    {
        SceneManager.LoadScene("Level2");
    }
}
