using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject distanceShadow;

    private Movement playerMovement;

    private MeshRenderer mRenderer;
    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        playerMovement = FindObjectOfType<Movement>();
        SetDestination();
    }

    private void FixedUpdate()
    {
        if (playerMovement.IsObjectInFront())
        {
            SetDestination();
            mRenderer.enabled = true;
            distanceShadow.gameObject.SetActive(true);
        }
        else
        {
            mRenderer.enabled = false;
            distanceShadow.gameObject.SetActive(false);
        }
    }

    public void SetDestination()
    {
        transform.position = playerMovement.hit.collider.gameObject.transform.position;
        transform.localScale = player.transform.localScale;
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        transform.rotation = player.transform.rotation;
    }
}