using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeLeft;
    public bool timer;

    public TMP_Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            timeLeft -= Time.deltaTime;
            text.text = "" + Mathf.Round(timeLeft);
            if (timeLeft < 0)
            {
                timer = false;
                //insert behavior here
            }
        }
    }



}
