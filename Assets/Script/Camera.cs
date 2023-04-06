using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    private Vector3 offSet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offSet = transform.position - player.position;
        
    }

    private void LateUpdate()
    {
        Vector3 newPostion = new Vector3(transform.position.x, transform.position.y, player.position.z + offSet.z);
        transform.position = newPostion;
    }
}
