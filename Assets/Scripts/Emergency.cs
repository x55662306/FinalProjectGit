using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emergency : MonoBehaviour
{
    public int rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed*Time.deltaTime, 0));
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Player" && Input.GetKey(KeyCode.R))
        {
            int health = other.transform.GetComponent<Player>().GetHealth();
            if (health < 100)
            {
                if(StaticVarible.score >= (100-health)/2)
                {
                    StaticVarible.score -= (100 - health) / 2;
                    other.transform.GetComponent<Player>().SetHealth(100);
                }
            }
        }
    }
}
