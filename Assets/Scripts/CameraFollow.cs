using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 offset = new Vector3(2f,2.5f,-5f);

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
