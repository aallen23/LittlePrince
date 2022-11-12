using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Level5Controller : MonoBehaviour
{
    [SerializeField] Touch touch;
    [SerializeField] Timer timer;

    [SerializeField] Vector2 touchPos;

    public float screenHeight;
    public bool touching;
    public float lerp;
    public bool moving;

    public bool carrying;

    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public GameObject blackUIPanel;


    // Start is called before the first frame update
    void Start()
    {
        lerp = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timer)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    StartCoroutine(Lerp(gameObject.transform.position, touchPos));
                    //transform.position = Vector2.Lerp(transform.position, touchPos, Time.deltaTime);
                    Debug.Log("Told to move");
                }
            }
        }

        if (!timer.timer)
        {
            Ending();
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided");
        if (other.gameObject.CompareTag("Watering Can"))
        {
            PickUpWateringCan(other.gameObject);
        }
        if (other.CompareTag("Spikes"))
        {

        }
        if (other.CompareTag("Rose") && carrying)
        {
            //water rose here
        }
        if (other.CompareTag("Wall"))
        {
            //flip barricade up here
            //do a rotation lerp && set a rotation trigger bool
        }
    }

    public void PickUpWateringCan(GameObject wateringCan)
    {
        wateringCan.transform.parent = gameObject.transform;
        wateringCan.transform.localPosition = new Vector2(-1, 0);
        carrying = true;
        Debug.Log("picked up watering can");
    }

    public void ResetWateringCan()
    {
        //reset watering can to original location once rose is watered
    }

    IEnumerator Lerp(Vector3 startPos, Vector3 targetPos)
    {
        float time = 0;
        while (time < lerp)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, time / lerp);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
    }

    public void GameOver()
    {
        retryButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        blackUIPanel.SetActive(true);
    }

    public void Retry()
    {
        retryButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        blackUIPanel.SetActive(false);
        SceneManager.LoadScene("Level5");
    }

    public void Ending()
    {
        SceneManager.LoadScene("Ending");
    }
}
