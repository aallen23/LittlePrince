using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TriggerSpikes()
    {
        triggered = true;
    }

    public void Untrigger()
    {
        triggered = false;
    }




}
