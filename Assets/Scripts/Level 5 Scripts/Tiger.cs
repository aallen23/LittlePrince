using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Tiger : MonoBehaviour
{
    public Vector2 targetPos;
    public Vector2 startPos;
    private float speed;
    private bool moving;
    private int returning;
    private Spikes spikes;
    private Level5Controller player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Level5Controller>();
        startPos = transform.position;
        speed = 2.0f;
        moving = true;
        returning = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.Translate(Vector3.left * targetPos.x * returning * speed * Time.deltaTime);
            transform.Translate(Vector3.up * targetPos.y * returning * speed * Time.deltaTime);
        }
        if (transform.position.x > 20 || transform.position.x < -20 || transform.position.y < -8 || transform.position.y > 8)
        {
            transform.position = startPos;
            gameObject.SetActive(false);
            returning = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Spikes"))
        {
            spikes = other.gameObject.GetComponent<Spikes>();
            if(spikes.triggered == true)
            {
                returning = -1;
            }
        }

        if (other.CompareTag("Flower"))
        {
            player.UpdateHealthBar();
            returning = -1;
        }
    }

}
