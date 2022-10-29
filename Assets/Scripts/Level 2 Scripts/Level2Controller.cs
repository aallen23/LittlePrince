using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{

    [SerializeField] Touch touch;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Timer timer;

    public int health;
    public bool immune;
    public GameOverManager gmover;

    private int flickerCount;
    private float flickerDuration;
    [SerializeField] SpriteRenderer spriteRenderer;

    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = 3;
        flickerCount = 6;
        flickerDuration = 0.2f;
        immune = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            //gmover.GameOver();
        }
    }

    void FixedUpdate()
    {
        if (timer.timer)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    rb.MovePosition(touchPosition);
                }
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(health > 0 && !immune)
        {
            health--;
            UpdateHealthBar();
            StartCoroutine(SpriteFlicker());
        }
        Debug.Log("collided");
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

    public void UpdateHealthBar()
    {
        if(healthBar != null && healthBar.transform.GetChild(health) != null)
        {
            healthBar.transform.GetChild(health).gameObject.SetActive(false);
        }
        
    }

}
