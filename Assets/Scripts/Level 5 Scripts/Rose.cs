using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{

    public Animator animator;

    public bool damaged;
    public bool winded;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        damaged = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetBool("isDamaged", false);

        if (damaged)
            animator.SetBool("isDamaged", true);
        else if (!damaged)
            animator.SetBool("isDamaged", false);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tiger"))
        {
            damaged = true;

        }

    }

}
