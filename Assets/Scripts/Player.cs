using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public Animator anim;
    public int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        state = 0;
        if (Input.GetKey(KeyCode.W)) {
            this.transform.position += Vector3.forward * velocity * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            state = 1;
        }
        if (Input.GetKey(KeyCode.A)) { 
            this.transform.position += Vector3.left * velocity * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 270, 0);
            state = 1;
        }
        if (Input.GetKey(KeyCode.S)) { 
            this.transform.position += Vector3.back * velocity * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            state = 1;
        }
        if (Input.GetKey(KeyCode.D)) { 
            this.transform.position += Vector3.right * velocity * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
            state = 1;
        }
        anim.SetInteger("State", state);
    }
}
