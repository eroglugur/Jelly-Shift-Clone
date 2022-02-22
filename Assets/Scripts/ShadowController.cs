using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShadowController : MonoBehaviour
{
    public Transform[] obstacles;
    public int obstacleIndex = 0;

    private void Start()
    {
        SetDestination();
    }

    public void SetDestination()
    {
        transform.position = obstacles[obstacleIndex].position;
    }
}
