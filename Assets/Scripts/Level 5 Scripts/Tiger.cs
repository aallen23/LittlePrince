using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Tiger : MonoBehaviour
{
    public Vector2 targetPos;
    private Vector2 startPos;
    private float speed;
    private bool moving;
    private int returning;
    private Spikes spikes;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        speed = 3.0f;
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided");

        if (other.CompareTag("Spikes"))
        {
            spikes = other.gameObject.GetComponent<Spikes>();
            if(spikes.triggered == true)
            {
                moving = false;
                returning = -1;
            }
        }

        if (other.CompareTag("Flower"))
        {
            //play sound effect & animation
            //decrease health
            returning = -1;
        }
    }

}
