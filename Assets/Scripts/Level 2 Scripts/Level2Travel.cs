using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Travel : MonoBehaviour
{
    [SerializeField] float starSpeed = 2.0f;
    [SerializeField] float planetSpeed = 3.0f;

    private float Xbound = -25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Star"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * starSpeed, Camera.main.transform);
        }
        if (gameObject.CompareTag("Asteroid"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * planetSpeed, Camera.main.transform);
        }
        if (gameObject.CompareTag("Planet"))
        {
            if(transform.position.x > 5)
            {
                transform.Translate(Vector3.left * Time.deltaTime * planetSpeed, Camera.main.transform);
            }
            else
            {
                transform.position = new Vector3(5, 0, 0);
            }
        }

        if (transform.position.x <= Xbound)
        {
            Destroy(gameObject);
        }
    }
}
