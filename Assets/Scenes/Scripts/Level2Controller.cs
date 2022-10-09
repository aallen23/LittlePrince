using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{

    Touch touch;

    public float speed = 2f;
    public Rigidbody2D rb;

    public float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {

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

}
