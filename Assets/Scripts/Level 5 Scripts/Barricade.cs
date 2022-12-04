using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
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


    public void TriggerBarricade()
    {
        triggered = true;
    }

    public void Untrigger()
    {
        triggered = false;
    }

}
