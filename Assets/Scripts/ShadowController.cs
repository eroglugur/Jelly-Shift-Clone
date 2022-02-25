using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Timeline;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private RaycastHit hit;
    public LayerMask obstacleMask;

    private void Start()
    {
        SetDestination();
    }
    
    private void FixedUpdate()
    {
        SetDestination();
    }

    public void SetDestination()
    {
        if (IsObjectInFront())
        {
            transform.position = hit.collider.gameObject.transform.position;
            transform.localScale = player.transform.localScale;
            transform.position = new Vector3(transform.position.x, transform.localScale.y / 2, transform.position.z);
        }
    }
    
    public bool IsObjectInFront()
    {
        if (Physics.Raycast(player.transform.position, player.transform.TransformDirection(player.transform.forward), out hit, Mathf.Infinity, obstacleMask))
        {
            if (hit.collider.gameObject.CompareTag("Obstacle"))
            {
                return true;
            }
        }
        return false;
    }
  
}
