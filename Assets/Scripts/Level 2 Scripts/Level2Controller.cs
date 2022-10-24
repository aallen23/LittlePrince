using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{

    [SerializeField] Touch touch;
    [SerializeField] Rigidbody2D rb;

    public int health;
    public GameOverManager gmover;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            gmover.GameOver();
        }
    }

    void FixedUpdate()
    {

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                rb.MovePosition(touchPosition);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(health > 0)
        {
            health--;
        }
        Debug.Log("collided");
    }

}
