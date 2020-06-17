using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State
    {
        support,
        recieve
    }
    
    public Animator anim;
    private State state;
    private GameObject spawner;
    public float velocity;
    public float rotateVelocity;
    public float moveSpeed;
    public int health;
    public int action = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(action<2)
            action = 0;
        float mouseX = Input.GetAxis("Mouse X") * moveSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * moveSpeed;
        //Camera.main.transform.localRotation = Camera.main.transform.localRotation * Quaternion.Euler(-mouseY, 0, 0);
        transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouseX, 0);
        if (Input.GetKey(KeyCode.W) && action < 2)
        {
            this.transform.position += this.transform.forward * velocity * Time.deltaTime;
            action = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, -rotateVelocity * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S) && action < 2)
        {
            this.transform.position += -this.transform.forward * velocity * Time.deltaTime;
            action = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, rotateVelocity * Time.deltaTime, 0);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Stand") && action > 1)
            action=0;
        anim.SetInteger("action", action);
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

    public void SetAction(int action)
    {
        this.action = action;
    }
}
