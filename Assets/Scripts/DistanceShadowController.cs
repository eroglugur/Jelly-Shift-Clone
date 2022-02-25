using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceShadowController : MonoBehaviour
{
    [SerializeField] private GameObject mainShadow;
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (!ShadowController.obstacleLeft)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.localScale = new Vector3(mainShadow.transform.localScale.x, mainShadow.transform.localScale.y, Mathf.Abs((mainShadow.transform.position.z - player.transform.position.z)));
        
        transform.position = new Vector3(transform.position.x, transform.localScale.y / 2, player.transform.position.z + transform.localScale.z / 2);

        
    }
}
