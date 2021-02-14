using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeDoor : Door
{
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (open)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
    }
}
