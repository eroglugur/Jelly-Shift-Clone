using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Timeline;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public Transform[] obstacles;
    public int obstacleIndex = 0;

    public static bool obstacleLeft = true;

    private void Start()
    {
        SetDestination();
        transform.localScale = player.transform.localScale;
        transform.position = new Vector3(transform.position.x, transform.localScale.y / 2, transform.position.z);
    }

    private void Update()
    {
        if (!obstacleLeft)
        {
            gameObject.SetActive(false);
        }
    }
    
    private void FixedUpdate()
    {
        transform.localScale = player.transform.localScale;
        transform.position = new Vector3(transform.position.x, transform.localScale.y / 2, transform.position.z);
    }

    public void SetDestination()
    {
        if (obstacleIndex == obstacles.Length)
        {
            obstacleLeft = false;
        }
        
        transform.position = obstacles[obstacleIndex].position;
    }
}
