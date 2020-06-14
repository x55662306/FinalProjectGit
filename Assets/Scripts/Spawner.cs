using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool full;

    // Start is called before the first frame update
    void Start()
    {
        full = false;
    }

    public bool getFull()
    {
        return full;
    }

    public void setFull(bool full)
    {
        this.full = full;
    }

}
