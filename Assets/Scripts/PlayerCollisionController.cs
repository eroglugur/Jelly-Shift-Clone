using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
using Vector3 = UnityEngine.Vector3;

public class PlayerCollisionController : MonoBehaviour
{
    public GameObject virtualCamera;
    
    private Rigidbody rb;
    private ShadowController shadowController;

    public static bool levelFinished;

    
    private void Start()
    {
        virtualCamera.gameObject.SetActive(true);
        rb = GetComponent<Rigidbody>();
        shadowController = FindObjectOfType<ShadowController>();
        levelFinished = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Handheld.Vibrate();
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            shadowController.obstacleIndex++;
            shadowController.SetDestination();
            Movement.speed += 100;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            levelFinished = true;
            if (transform.rotation.y == 0)
            {
                transform.DOMoveZ(transform.localPosition.z + 3, 1);
            }
            else
            {
                transform.DOMoveX(transform.localPosition.x + 3, 1);

            }

        }

        if (other.gameObject.CompareTag("Turn"))
        {
            transform.DORotate(new Vector3(0,90,0), 0f, RotateMode.WorldAxisAdd);
        }

        if (other.gameObject.CompareTag("Fall"))
        {
            virtualCamera.gameObject.SetActive(false);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (transform.rotation.y == 0)
            {
                transform.DOMoveZ(transform.localPosition.z - 3, 1);
            }
            else
            {
                transform.DOMoveX(transform.localPosition.x - 3, 1);

            }
        }

        if (other.gameObject.CompareTag("Jump"))
        {
            rb.AddForce(Vector3.up * 40f, ForceMode.Impulse);
        }
    }
    
}
