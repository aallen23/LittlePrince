using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public Vector2 targetPos;
    public Vector2 startPos;
    private float speed;
    private bool moving;
    private Barricade wall;
    private Level5Controller player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Level5Controller>();
        startPos = transform.position;
        speed = 3.0f;
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.Translate(Vector3.left * targetPos.x * speed * Time.deltaTime);
            transform.Translate(Vector3.up * targetPos.y * speed * Time.deltaTime);
        }
        if(transform.position.x > 18 || transform.position.x < -18)
        {
            transform.position = startPos;
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided");

        if (other.CompareTag("Wall"))
        {
            wall = other.gameObject.GetComponent<Barricade>();
            if (wall.triggered == true)
            {
                Reset();
            }
        }

        if (other.CompareTag("Flower"))
        {
            player.UpdateHealthBar();
            Reset();
        }

        

    }

    public void Reset()
    {
        moving = false;
        transform.position = startPos;
        gameObject.SetActive(false);
        moving = true;
    }


}
