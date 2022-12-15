using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private SpriteRenderer spikesUp;
    private SpriteRenderer spikesDown;
    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        spikesUp = GetComponent<SpriteRenderer>();
        spikesDown = transform.GetChild(0).GetComponent<SpriteRenderer>();
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TriggerSpikes()
    {
        spikesDown.enabled = false;
        spikesUp.enabled = true;
        triggered = true;
    }

    public void Untrigger()
    {
        spikesDown.enabled = true;
        spikesUp.enabled = false;
        triggered = false;
    }




}
