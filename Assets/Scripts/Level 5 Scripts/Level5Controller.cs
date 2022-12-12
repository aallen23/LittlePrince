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
    public bool spawning;
    public Animator animator;

    private GameObject wateringCan;
    public GameObject rose;
    public GameObject speechBubble;
    public GameObject[] triggers;

    private Vector2 wateringCanPos;
    private Vector2 princeOriginalPos;

    private float delay;
    private float triggerDelay;
    private float spawnDelay;
    private int trigger;

    public bool carrying;
    public bool watering;
    public bool roseNeedsWatering;
    public bool roseIsWatered;

    private Spikes spikes;
    private Barricade wall;

    public int health;
    public GameObject healthBar;

    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public GameObject blackUIPanel;


    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        lerp = 1.0f;
        moving = false;
        roseNeedsWatering = false;
        watering = false;
        delay = 1.0f;
        triggerDelay = 4.0f;
        spawnDelay = 6.0f;
        princeOriginalPos = transform.position;
        spawning = true;
        StartCoroutine(Spawn());
        //start a coroutine that
        //1) pauses for five seconds before spawning starts
        //2) starts spawning process
        //3) picks spawn integer
        //4) calls new method based on spawn integer
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("hasCan", false);
        if (speechBubble.activeInHierarchy == true)
        {
            roseNeedsWatering = true;
            StartCoroutine(UntriggerSpeechBubble());
        }

        if (timer.timer && moving == false && watering == false && health > 0)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    animator.SetBool("isWalking", true);
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    StartCoroutine(Lerp(gameObject.transform.position, touchPos));
                    Debug.Log("Told to move");
                }
            }
        }

        if (health == 0)
        {
            GameOver();
        }

        if (!timer.timer)
        {
            //if (flowerScore > flowerHS)
            //{
            //    flowerHS = flowerScore;
            //    PlayerPrefs.SetInt("FlowerHighScore", flowerHS);
            //}
            //PlayerPrefs.SetInt("FlowerCurrent", flowerScore);
            //timeIsUp.TimeUp();
            Ending();
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided");
        if (other.gameObject.CompareTag("Watering Can") && roseNeedsWatering)
        {
            animator.SetBool("hasCan", true);
            carrying = true;
            watering = true;
            wateringCan = other.gameObject;
            wateringCanPos = wateringCan.transform.position;
            StartCoroutine(PickUpWateringCan(wateringCan));
        }
        if (other.CompareTag("Spikes"))
        {
            spikes = other.gameObject.GetComponent<Spikes>();
            spikes.TriggerSpikes();
            Debug.Log("triggered");
            StartCoroutine(UntriggerSpikes());
        }
        if (other.CompareTag("Flower") && carrying)
        {
            Debug.Log("watering flower");
            roseIsWatered = true;
            speechBubble.SetActive(false);
            //water rose here
            //animation
            //return watering can to start position
        }
        if (other.CompareTag("Wall"))
        {
            Debug.Log("rotate");
            //other.gameObject.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
            wall = other.gameObject.GetComponent<Barricade>();
            wall.TriggerBarricade();
            StartCoroutine(UntriggerBarricade());
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
        while (spawning)
        {
            yield return new WaitForSeconds(spawnDelay);
            trigger = Random.Range(0, triggers.Length);
            triggers[trigger].SetActive(true);
        }
    }


    IEnumerator PickUpWateringCan(GameObject wateringCan)
    {
        wateringCan.transform.parent = gameObject.transform;
        wateringCan.transform.localPosition = new Vector2(-1, 0);
        Debug.Log("picked up watering can");
        //lerp to rose position
        yield return new WaitForSeconds(delay);
        StartCoroutine(Lerp(gameObject.transform.position, rose.transform.position));
        yield return new WaitForSeconds(2.0f);
        wateringCan.transform.SetParent(null);
        ResetWateringCan();
        StartCoroutine(Lerp(transform.position, princeOriginalPos));
        watering = false;
        //once lerp is done, return watering can (use cases & booleans to test for watering)
    }

    public void ResetWateringCan()
    {
        if(wateringCan != null)
        {
            wateringCan.transform.position = wateringCanPos;
        }
        //reset watering can to original location once rose is watered
    }


    IEnumerator UntriggerSpeechBubble()
    {
        yield return new WaitForSeconds(10.0f);
        if (!roseIsWatered)
        {
            UpdateHealthBar();
            speechBubble.SetActive(false);
        }
    }


    IEnumerator UntriggerSpikes()
    {
        yield return new WaitForSeconds(triggerDelay);
        spikes.Untrigger();
        Debug.Log("untriggered");
    }


    IEnumerator UntriggerBarricade()
    {
        yield return new WaitForSeconds(triggerDelay);
        wall.Untrigger();
        Debug.Log("untriggered");
    }

    public void UpdateHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
        }
        if (healthBar != null && healthBar.transform.GetChild(health) != null)
        {
            healthBar.transform.GetChild(health).gameObject.SetActive(false);
        }
    }

    public void ResetHealthBar()
    {
        for (int i = 0; i < health; i++)
        {
            if (healthBar != null && healthBar.transform.GetChild(i) != null)
            {
                healthBar.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }


    public void GameOver()
    {
        retryButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        blackUIPanel.SetActive(true);
    }

    public void Retry()
    {

        health = 4;
        ResetHealthBar();
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
