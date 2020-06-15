using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public float velocity;
    public float rotateVelocity;
    public float moveSpeed;
    public int health;
    public int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        state = 0;
        float mouseX = Input.GetAxis("Mouse X") * moveSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * moveSpeed;
        //Camera.main.transform.localRotation = Camera.main.transform.localRotation * Quaternion.Euler(-mouseY, 0, 0);
        transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouseX, 0);
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += this.transform.forward * velocity * Time.deltaTime;
            state = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, -rotateVelocity * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += -this.transform.forward * velocity * Time.deltaTime;
            state = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, rotateVelocity * Time.deltaTime, 0);
        }
        anim.SetInteger("State", state);
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
