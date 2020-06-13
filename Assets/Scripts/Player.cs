using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public float rotateVelocity;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
            this.transform.position += this.transform.forward * velocity * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            this.transform.Rotate(0, -rotateVelocity * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.S))
            this.transform.position += -this.transform.forward * velocity * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            this.transform.Rotate(0, rotateVelocity * Time.deltaTime, 0);
    }

    public void AddHealth(int deltaHealth)
    {
        this.health += deltaHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }
}
