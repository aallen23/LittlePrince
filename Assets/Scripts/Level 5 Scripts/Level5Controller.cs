using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq.Expressions;


public class Level5Controller : MonoBehaviour
{
    [SerializeField] Touch touch;
    [SerializeField] Timer timer;

    [SerializeField] Vector2 touchPos;

    public float screenHeight;
    public bool touching;
    public float lerp;
    public bool moving;

    private GameObject wateringCan;
    private GameObject rose;

    private float delay;
    private int trigger;

    public bool carrying;

    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public GameObject blackUIPanel;


    // Start is called before the first frame update
    void Start()
    {
        lerp = 1.5f;
        moving = false;
        delay = 2.5f;
        //start a coroutine that
        //1) pauses for five seconds before spawning starts
        //2) starts spawning process
        //3) picks spawn integer
        //4) calls new method based on spawn integer
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timer && moving == false)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    StartCoroutine(Lerp(gameObject.transform.position, touchPos));
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
            wateringCan = other.gameObject;
            PickUpWateringCan(wateringCan);
        }
        if (other.CompareTag("Spikes"))
        {

        }
        if (other.CompareTag("Flower") && carrying)
        {
            Debug.Log("watering flower");
            //water rose here
            //animation
            //return watering can to start position
        }
        if (other.CompareTag("Wall"))
        {
            Debug.Log("rotate");
            other.gameObject.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            //flip barricade up here
            //do a rotation lerp && set a rotation trigger bool
            //use timer to set barricade to flip back to flat
        }
    }


    IEnumerator Lerp(Vector3 startPos, Vector3 targetPos)
    {
        float time = 0;
        while (time < lerp)
        {
            moving = true;
            transform.position = Vector3.Lerp(startPos, targetPos, time / lerp);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        moving = false;
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(delay);
        trigger = Random.Range(1, 3);
        switch(trigger)
        {
            case 1:
              //tiger
                break;
            case 2:
                //water
                break;
            case 3:
                //wind
                break;
            default:
                break;
        }
    }


    public void PickUpWateringCan(GameObject wateringCan)
    {
        wateringCan.transform.parent = gameObject.transform;
        wateringCan.transform.localPosition = new Vector2(-1, 0);
        carrying = true;
        Debug.Log("picked up watering can");
        //lerp to rose position
        StartCoroutine(Lerp(gameObject.transform.position, rose.transform.position));
        //once lerp is done, return watering can (use cases & booleans to test for watering)
    }

    public void ResetWateringCan()
    {
        //reset watering can to original location once rose is watered
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
