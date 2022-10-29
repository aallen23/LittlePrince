using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Touch touch;
    [SerializeField] Timer timer;

    private Vector2 tapPosition;
    private Rigidbody2D rb;
    private TimeIsUp timeIsUp;
    public TextMeshProUGUI flowerText;
    public int flowerScore;
    public int flowerHS;
    private float moveSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        timeIsUp = GameObject.Find("GameOverManager").GetComponent<TimeIsUp>();
        flowerScore = 0;
        flowerHS = PlayerPrefs.GetInt("FlowerHighScore");
        flowerText.text = "Flowers: " + flowerScore;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Can tap between y = 2 and y = -3
        //Get tap position then move prince to tap position
        if (timer.timer)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    if (touchPosition.y < 2 && touchPosition.y > -3)
                    {
                        rb.transform.position = Vector2.Lerp(rb.transform.position, touchPosition, Time.deltaTime);
                        Debug.Log("Told to move");
                        if (touchPosition.x > rb.transform.position.x)
                        {
                            if (rb.transform.localScale.x < 0)
                            rb.transform.localScale = new Vector2((rb.transform.localScale.x * -1), rb.transform.localScale.y);
                        }
                        else if (touchPosition.x < rb.transform.position.x)
                        {
                            if (rb.transform.localScale.x > 0)
                                rb.transform.localScale = new Vector2((rb.transform.localScale.x * -1), rb.transform.localScale.y);
                        }
                    }
                }
            }
        }

        if (timer.timeLeft <= 0)
        {
            if (flowerScore > flowerHS)
            {
                flowerHS = flowerScore;
                PlayerPrefs.SetInt("FlowerHighScore", flowerHS);
            }
            timeIsUp.TimeUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (timer.timer)
        {
            if (other.gameObject.CompareTag("Flower"))
            {
                Destroy(other.gameObject);
                AddFlower(1);
            }
        }
    }

    private void AddFlower(int FlowerToAdd)
    {
        flowerScore += FlowerToAdd;
        flowerText.text = "Flowers: " + flowerScore;
    }
}
