﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            this.transform.position += Vector3.forward * velocity * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            this.transform.position += Vector3.left * velocity * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            this.transform.position += Vector3.back * velocity * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            this.transform.position += Vector3.right * velocity * Time.deltaTime;
    }
}
