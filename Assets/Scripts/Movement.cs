using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public static float speed = 750f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.levelFinished && GameManager.isGameActive)
        {
            GameManager.isGameStarted = true;
            rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
        }
    }

}   