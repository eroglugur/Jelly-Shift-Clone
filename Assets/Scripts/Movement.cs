using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public static float speed;
    public static float speedLimit;

    public RaycastHit hit;
    public LayerMask obstacleMask;

    private void Start()
    {
        speed = 750f;
        speedLimit = 1050f;
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
    
    public bool IsObjectInFront()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, obstacleMask))
        {
            if (hit.collider.gameObject.CompareTag("Obstacle"))
            {
                return true;
            }
        }

        return false;
    }

}   