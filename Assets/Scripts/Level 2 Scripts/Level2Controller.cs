using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Level2Controller : MonoBehaviour
{

    [SerializeField] Touch touch;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Timer timer;

    public float screenHeight;
    public bool touching;
    public float lerp;

    public float xBound;
    public float yBound;
    public Vector2 targetPos;
    public Vector3 targetScale;
    public float shrink;
    public GameObject planet;

    public int health;
    public bool immune;
    public GameObject gm;
    public GameObject spawnHolder;

    private int flickerCount;
    private float flickerDuration;
    [SerializeField] SpriteRenderer spriteRenderer;

    public GameObject healthBar;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public GameObject blackUIPanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        screenHeight = Screen.height;
        xBound = -8.0f;
        yBound = 3.0f;
        lerp = 8.0f;
        shrink = 50.0f;
        health = 3;
        flickerCount = 6;
        flickerDuration = 0.2f;
        immune = false;
        touching = false;
        targetScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            GameOver();
        }

        if (!timer.timer)
        {
            
            IdentifyPlanet();
            StartCoroutine(Shrink());
        }
    }

    void FixedUpdate()
    {
        if (timer.timer && health > 0)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    touching = true;
                }
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    if (touch.position.y > (screenHeight / 2))
                    {
                        targetPos = new Vector2(xBound, yBound);
                        StartCoroutine(Lerp(targetPos));
                    }
                    if (touch.position.y < (screenHeight / 2))
                    {
                        targetPos = new Vector2(xBound, -yBound);
                        StartCoroutine(Lerp(targetPos));
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    touching = false;
                }
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(health > 0 && !immune && timer.timer)
        {
            health--;
            UpdateHealthBar();
            StartCoroutine(SpriteFlicker());
        }
    }

    IEnumerator Lerp(Vector3 targetPos)
    {
        float time = 0;
        while (touching == true)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, time / lerp);
            time += Time.deltaTime;
            yield return null;
        }

    }

    IEnumerator SpriteFlicker()
    {
        immune = true;
        if (immune)
        {
            for(int i = 0; i < flickerCount; i++)
            {
                spriteRenderer.enabled = !(spriteRenderer.enabled);
                yield return new WaitForSeconds(flickerDuration);
                immune = false;
            }
        }
    }

    IEnumerator Shrink()
    {
        yield return new WaitForSeconds(2.0f);
        float time = 0;
        while (time < shrink)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, time / shrink);
            transform.position = Vector2.Lerp(transform.position, planet.transform.position, time / shrink);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;
    }

    public void IdentifyPlanet()
    {
        if (GameObject.FindWithTag("Planet") != null)
        {
            planet = GameObject.FindWithTag("Planet");
        }
    }

    public void UpdateHealthBar()
    {
        if(healthBar != null && healthBar.transform.GetChild(health) != null)
        {
            healthBar.transform.GetChild(health).gameObject.SetActive(false);
        }
    }

    public void ResetHealthBar()
    {
        for(int i = 0; i < health; i++)
        {
            if (healthBar != null && healthBar.transform.GetChild(i) != null)
            {
                healthBar.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void DestroyAll()
    {
        for (int i = 0; i < spawnHolder.transform.childCount; i++)
        {
            Destroy(spawnHolder.transform.GetChild(i).gameObject);
        }
    }

    public void GameOver()
    {
        DestroyAll();
        retryButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        blackUIPanel.SetActive(true);
    }

    public void Retry()
    {
        health = 3;
        ResetHealthBar();
        retryButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        blackUIPanel.SetActive(false);
        SceneManager.LoadScene("Level2");
    }

}
