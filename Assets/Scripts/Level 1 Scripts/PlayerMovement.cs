using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 tapPosition;
    private Rigidbody rb;
    private float moveSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Can tap between y = 2 and y = -3
        //Get tap position then move prince to tap position
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
        }
    }
}
