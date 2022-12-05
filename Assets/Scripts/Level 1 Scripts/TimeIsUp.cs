using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeIsUp : MonoBehaviour
{
    private Timer Timer;
    public GameObject blackSquare;
    public GameObject meanwhileText;

    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
        blackSquare.gameObject.SetActive(false);
        meanwhileText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public IEnumerator TimeUp()
    {
        blackSquare.gameObject.SetActive(true);
        meanwhileText.gameObject.SetActive(true);
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Level2");
    }
}
