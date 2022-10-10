using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Travel : MonoBehaviour
{
    [SerializeField] float starSpeed = 10.0f;
    [SerializeField] float planetSpeed = 5.0f;

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
        if (gameObject.CompareTag("Planet"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * planetSpeed, Camera.main.transform);
        }

        if (transform.position.x <= Xbound)
        {
            Destroy(gameObject);
        }
    }
}
