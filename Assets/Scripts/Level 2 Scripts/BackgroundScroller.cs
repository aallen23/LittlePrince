using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    private float speed = 5.0f;
    private Vector3 startPos;
    private float repeatWidth;
    [SerializeField] Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer.timer)
        {

            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (transform.position.x < startPos.x - repeatWidth)
            {
                transform.position = startPos;
            }
        }

    }
}