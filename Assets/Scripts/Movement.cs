using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public static float speed = 750f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PlayerCollisionController.levelFinished)
        {
            rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
        }
    }
}