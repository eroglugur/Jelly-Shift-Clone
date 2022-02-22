using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private ShadowController shadowController;

    private void Start()
    {
        shadowController = FindObjectOfType<ShadowController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            shadowController.obstacleIndex++;
            shadowController.SetDestination();
        }
    }
}
