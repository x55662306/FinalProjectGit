﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTip : MonoBehaviour
{
    private GameObject target;
    private GameObject player;
    private float minimapRadius = 14.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = target.transform.position - player.transform.position;
        float dist = vec.magnitude;
        if (dist < minimapRadius)
            this.transform.position = target.transform.position;
        else
            this.transform.position = player.transform.position + vec.normalized * minimapRadius;
    }
}